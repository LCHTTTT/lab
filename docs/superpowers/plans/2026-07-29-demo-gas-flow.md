# Demo Gas Flow Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Make the Demo gas-collection sequence repeatable: exhaust air, produce gas, overflow the collection bottle, then report success.

**Architecture:** A small pure C# state machine advances from elapsed heating time rather than particle-collision counts. `lzpz` owns all three particle effects and feeds the state machine with heating and collection-bottle conditions; legacy collision counters remain only as telemetry.

**Tech Stack:** Unity 2020.3, C#, Unity ParticleSystem, local .NET console test harness.

## Global Constraints

- Do not change database or login code.
- Keep scene references currently assigned to `lzpz` and `yichu`.
- Make phase durations inspector-configurable.

### Task 1: Testable phase state machine

**Files:**

- Create: `Tests/GasExperimentFlow/GasExperimentFlowTests.cs`
- Create: `Assets/Scripts/paishuifa/GasExperimentFlow.cs`

- [ ] Write tests for deterministic phase progression, collection gating, and reset.
- [ ] Run the tests and observe failure before the state machine exists.
- [ ] Implement the minimal pure state machine.
- [ ] Run the tests and confirm success.

### Task 2: Wire the Demo particle effects

**Files:**

- Modify: `Assets/Scripts/paishuifa/lzpz.cs`
- Modify: `Assets/Scripts/paishuifa/yichu.cs`
- Modify: `Assets/Scripts/paishuifa/qit.cs`
- Modify: `Assets/Scripts/common/quanjujingtai.cs`

- [ ] Use the state machine in `lzpz` and make it the sole owner of `pnqt`, `ypqt`, and `ycqt` during the experiment.
- [ ] Replace collection success checks based on collision count with the completed flow state.
- [ ] Reset all flow state on scene initialization.
- [ ] Compile and run the focused test harness.
