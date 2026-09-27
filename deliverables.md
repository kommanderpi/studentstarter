# DigiPhant deliverables

## Assignment

In groups of **3 students**, prototype a digital twin of a collective performance:
use real-world movement data to control a shared elephant in Unity. The exercise
runs for **2.5 weeks**.

You are expected to use AI coding agents to help build the implementation.
Your responsibility is to decide how the components connect, what the data means,
how each performer contributes, and how to test whether the prototype works.
You do not need to write every line of code yourself, but you must be able to
explain the system's behaviour and the evidence behind your design choices.

Use the supplied components and reference project as starting points. You may
choose a distributed arrangement or a physical ensemble, and full-body or seated
controls. Every student must contribute meaningfully to the performance.

## 1. Working integrated prototype

Submit an editable Unity project with the rigged elephant, required assets,
tracking bridge, dependency specifications, and setup instructions.

The prototype must demonstrate:

- Live movement tracking connected to Unity.
- A clear assignment of all three performers to elephant controls.
- Neutral-pose calibration and a way to restart or reassign tracking.
- A visible response to each performer's input.
- Defined behaviour when an input is missing or unreliable.
- A short coordinated action with a beginning, middle, and end.

Examples include a greeting, noticing and reaching toward something, or a
coordinated step. Travel through the scene is optional if the intended action
can be expressed in place. Reliability and understandable control matter more
than the number of features.

Include the files needed to reopen the project: Unity's `Assets` directory with
its `.meta` files, `Packages`, `ProjectSettings`, and your tracking source and
supporting files. Include instructions to recreate the Python environment;
exclude the local `.venv`, Unity `Library`, and temporary files. Preserve a
recoverable baseline alongside your final version or through version history.

## 2. System and mapping diagram

Provide a diagram showing the complete path from physical performance to the
digital elephant:

**Performers → camera → pose estimation → performer assignment → movement
signals → calibration and filtering → Unity controls → elephant behaviour.**

Identify where each component runs, what data passes between components, and
which parts were supplied, configured, or changed by your group.

Include a mapping table with these fields:

| Performer | Physical input | Measured signal | Neutral position | Elephant response | Missing-input behaviour |
| --- | --- | --- | --- | --- | --- |
| Example: P3 | Raise right hand | Wrist height relative to shoulders | Hand at a comfortable resting height | Curl trunk | Return gradually toward neutral |

Explain how multiple inputs combine, including any movement that affects more
than one elephant part. Distinguish what MediaPipe estimates from the meaning
your group assigns to those estimates.

## 3. Real-world data collection and comparison

Choose one repeatable action and one practical question about the system. For
example: does spacing the performers farther apart reduce tracking loss, or does
a seated mapping make the action easier to repeat?

Record **at least three short trials before a revision and three after it**.
Keep the action and other conditions as similar as practical, and change one
main factor. Agree on what counts as success before collecting the trials.

Submit:

- A brief protocol: action, duration, camera arrangement, movement mode,
  calibration procedure, changed factor, and success criterion.
- Machine-readable data in CSV or JSON containing elapsed timestamps,
  performer IDs, the movement signals relevant to your question, and their
  confidence values. Mark missing tracking explicitly so it is distinguishable
  from a valid neutral value.
- A trial log with conditions, observed successes or failures, and notes on
  occlusion, identity changes, or unexpected elephant behaviour.
- A small table or plot comparing the two conditions, with an explanation of
  what the results support and what remains uncertain.

Possible measures include completed actions, tracking interruptions, time to
complete the action, or unintended movement while holding neutral. Explain how
you calculate your chosen measure. Treat tracking confidence as a model signal,
not as proof that a pose estimate is correct.

Raw video is optional; movement logs and observation notes are sufficient.
Use performer labels such as P1–P3 in the submitted data and describe any
recording to participants before collecting it.

## 4. Iteration and agent-use record

Submit a concise record of **at least two meaningful revisions**. For each,
show the observation, proposed change, test, result, and decision to keep or
revise it. At least one revision must connect to the before-and-after trials.

Include feedback from another group trying your prototype. Record what they
could understand or repeat, where they struggled, and how you responded.

Summarize how you used your coding agents. Include a few representative requests
and explain how you checked the resulting changes. Note one suggestion you
corrected, rejected, or refined if applicable. A complete chat transcript is
not required.

## 5. Collective performance and explanation

Prepare a **3–5 minute demonstration**, subject to the instructor's presentation
schedule:

1. Show the coordinated action with all three students participating.
2. Demonstrate individual controls so viewers can connect human movement to
   elephant behaviour.
3. Explain the data path and your most important mapping decision.
4. Show one tested revision and its evidence.
5. Demonstrate or explain how to recover from a tracking interruption.

All three students should be able to explain their own input and how it
contributes to the shared result.

## 6. Launch guide and digital-twin reflection

Provide short instructions that another group can follow from a fresh launch:

- Required Unity and Python versions and supported operating systems actually
  tested by your group.
- Dependency installation, scene to open, and how to start the camera bridge.
- Camera framing, performer arrangement, and control assignments.
- How to set neutral, perform the action, stop, and recover from lost tracking.
- Known limitations and practical workarounds.

Include a brief reflection addressing:

- What physical system does your elephant represent: individual bodies, the
  group's formation, coordinated gestures, or a combination?
- Which properties are measured, inferred, transformed, or left out?
- What makes this a useful digital-twin prototype, and where does the analogy
  have limits?
- How do calibration, latency, missing data, and performer identity affect the
  relationship between the physical and digital systems?
- What did the collected data reveal that watching the elephant alone did not?
- What would you test next before claiming the system works reliably beyond
  your own group and setup?

## Checkpoints

| When | Evidence to show |
| --- | --- |
| End of week 1 | Live tracking connected to the elephant, a first system and mapping diagram, a contribution from each performer, and a trial protocol |
| End of week 2 | A repeatable collective action, before-and-after trial data, peer feedback, and a revision record |
| Final half-week | Final project, launch guide, diagrams, data and comparison, iteration and agent-use record, reflection, and demonstration |

## Submission structure

Use clear folders or equivalent links so each deliverable is easy to locate:

```text
GroupName/
  README.md                 # Launch guide and links to deliverables
  UnityProject/             # Editable project and tracking source
  diagrams/                 # System diagram and mapping table
  data/                     # Trial protocol, signal logs and observations
  analysis/                 # Before-and-after comparison
  process/                  # Revisions, peer feedback and agent-use record
  reflection.md             # Digital-twin interpretation and limitations
```

## What the work should demonstrate

The emphasis is on a working integration you can explain, purposeful collective
control, real-world evidence informing revisions, and an honest account of what
the digital representation captures and misses. Code volume and the number of
agent-generated features are not measures of success. Grading weights, if any,
will be specified separately by the instructor.
