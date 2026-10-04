# Duel arena lifetime and disc delay fix

The published Duel mod retained arena objects after matches and replacements. In two controlled legacy-network reproductions, accumulated interiors filled the 1,023 usable ghost slots. The server continued creating discs promptly, but their authoritative client arrival became roughly 550 ms slower. Removing only the extra arena objects restored the earlier timing.

This change fixes that retained-object growth. It covers arena ownership, reusable slots and offsets, the related Nexus allocation leak, and countdown lifetime. Other findings from the broader mod audit remain separate work.

## Changes

- `TDArena.cs`: gameplay arenas own their geometry through a `SimGroup`. Both teams reference their match's instance. Teardown frees its slot and world offset; later matches reuse them. Allocation refuses exhausted pools. Repeated setup of the same match reuses its instance. Each arena table starts with a reset object counter.
- `DuelCompat.cs` and `DMMain.cs`: deathmatch teardown deletes its arena. Replacements discard the preceding instance, and countdown callbacks belong to that instance. Project imports retain flat `BuildGroup` ownership through a non-owning reservation set, without changing active deathmatch spawns.
- `TDMain.cs` and `TDSupport.cs`: match completion and abort release the correct team arena. Nexus initialization reuses its existing five objects and repairs partial sets.
- `catalog.json`: Duel advances from version 2 to version 3. The independent Asset Store descriptor is generated from the committed content; the game updater manifest is unchanged.

Disc fire/reload timing, statistics, prediction, packet settings and protocol are unchanged. Arena construction still runs synchronously.

## Headless validation

The exact deployed script bytes were checked against the candidate pack. Tests ran in private game trees on Duelmap4, using the native dedicated host and a headless client. The lifecycle fixture passed **145 checks, zero failures**, including:

- Forty ordinary deathmatch stop/start transitions, alternating two arenas: recursive mission object count remained **129 before and after**.
- Concurrent team instances, repeated setup, releasing either team's handle, and retaining the other match's geometry.
- Nine occupied slots, rejection of a tenth, world-offset exhaustion, and reuse after release.
- Project geometry staying directly in `BuildGroup`, surviving deathmatch teardown, and releasing its reservation after deletion.
- Forty Nexus hide/reinitialize cycles without growth, and cancellation of callbacks owned by a deleted arena.

Network tests added 50 ms of receive delay in each direction, with no injected loss or jitter. Each mode fired 12 ordinary ready-state disc shots per phase, 2.2 seconds apart, with an 80 ms hold. Prediction was disabled so authoritative arrival could be measured separately. Each replacement phase rebuilt the arena 24 times, one replacement every 0.2 seconds; measurements started after the rebuilds and a 12-second phase warmup. Cleanup came from the production scripts.

| Connection | Fresh: median input to received disc | After 24 replacements | After 48 replacements | Matched shots |
| --- | ---: | ---: | ---: | ---: |
| Legacy | 202.55 ms | 186.26 ms | 188.90 ms | 36 / 36 |
| Modern 1.50 | 204.27 ms | 224.60 ms | 210.60 ms | 36 / 36 |

The earlier unpatched legacy accumulation tests measured **198.21 / 753.24 / 213.27 ms** and **202.75 / 751.34 / 186.68 ms** for fresh / accumulated / manually cleaned phases. The fixed replacement tests have no accumulating extra arenas and no comparable half-second feedback increase. These are distinct test runs, not same-session paired measurements or a promise of a particular WAN latency.

The regression source is [tests/duel/arena-lifetime.cs](tests/duel/arena-lifetime.cs). Machine-readable phase statistics, script hashes and raw-log hashes are in [tests/duel/arena-lifetime-results.json](tests/duel/arena-lifetime-results.json). Raw logs and the instrumented timing harness are retained in the implementation workspace under `output/duel-arena-fix` and `output/argh-duel-trigger-tests-2026-10-03`.

To rerun the lifecycle fixture, use an isolated empty Duel host with Duelmap4's default Arena_Madness deathmatch initialized. Copy the fixture into its script search path, execute it after mission startup, then schedule `ArenaFix::Run()` after startup has settled (the validation used 14 seconds). It deliberately starts and stops matches. Expect `[ARENAFIX-DONE] checks=145 failures=0 total=129` with no `[ARENAFIX-FAIL]` lines from that run.

## Scope and rollout

This was tested on Windows native host/client binaries with induced latency. The original affected Linux/Wine host and WAN session were not captured, and no physical click-to-rendered-frame measurement or populated team scoring match is claimed. The stripped timing harness reported the same six non-disc arrow/pyramid asset warnings as the earlier controls; standard disc assets loaded.

Update the Duel Asset Store pack and **restart the running mission or server**. Objects created by the old scripts have no instance owner and cannot be recovered retroactively by loading the new functions. No native engine rebuild or client-side weapon change is required.
