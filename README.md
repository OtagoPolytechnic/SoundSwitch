# SoundSwitch
This program is an accessibility tool, intended for those with diminished motor
control - typically those users also rely on the usage of eye-tracking software
and hardware, which this program functions in tandem with.

This program was developed as a senior project for part of the Bachelor of
Information Technology at Otago Polytechnic.

## Purpose & Reason
The purpose of this program is to provide an additional interface between the user
and their device. SoundSwitch allows users to quickly execute customisable keybindings
with their microphone, reducing the reliance on mechanical inputs such as mice.

This software was primarily developed for use in tandem with eye-tracking hardware and software,
with the intent of eliminating some of the tedium of using those products, such as
awkward usage when multi-key inputs are required, or the issue of eye-strain,
particularly when performing a similar task many times (such as highlighting or saving text.)

## Installation
To build & execute this software on your computer, you will require the following:

* A valid installation of Visual Studio 2013 or greater.
* A microphone. Higher quality microphones will yield more accurate results.

Once Visual Studio is installed:
* Clone this repository to a local directory.
* Inside the repository, there are two folders. **sound-switch**, and **recorder-test**.
  * For modifying the *recording* code, open the .sln inside recorder-test directory.
  * For modifying the *binding-related* code, open the .sln inside sound-switch directory.

Additionally, we include a pre-compiled .exe for one of the functions provided by [scape-xcorrsound](https://github.com/openpreserve/scape-xcorrsound) in this repository.
If you wish to compile your own [scape-xcorrsound](https://github.com/openpreserve/scape-xcorrsound) library (and executables), please visit their repo and follow their provided instructions.
SoundSwitch only requires one function of their library, called overlap-analysis.
Note that their library does not natively support windows, and modifications to their source code are required to make it compile on windows.

## Usage
When you begin the program, you will be greeted with the home screen. You will need to perform some initial setup before this program will work correctly,
and some trial-and-error may be required before you right the correct detection values for your needs.
* Click the **settings** button.
  * If your recording device is present in the source list, simply double click it to set it as your current input.
    * If it is not, ensure that your recording device is properly plugged in, and click **refresh sources**.
  * Set your **detection level**. Detection level is a measure of how loud you must speak for your microphone to register commands.
  *(Note: From our testing, we found a detection level of ~500 to be adequate. Higher than this may lead to voice strain due to having to speak quite loudly to trigger a command.)*

* Once your settings have been configured, you will need to create a **binding**. A binding is a sound file that contains a short (~1 second) sound bite
that you record, a key-command and a name are attached to this sound file.
* To create a binding, follow these steps:
  * From the home screen, click the **bindings** button.
  * Click the **new binding** button.
  * Follow the prompt that appears, taking special care to record a sound that is short, and easily repeatable.
  A good example for a binding should include these properties:
    * A short, distinctive sound for its trigger. Try to avoid using full words for your bindings,
    as repeated usage of such binds can cause voice strain.
    * The command should sufficiently justify the usage of a bind, such as combination keys or F-keys.
    * A descriptive name that explains what the binding will achieve for your own recognition.

**An important note on bindings:** The more bindings you have, the longer the program will take to respond to commands.
Additionally, frequently used bindings should use very short verbal triggers to avoid vocal strain.

* Now that you (presumably) have one or more bindings, you can head back to the main screen,
and click **Begin Listening**. Your microphone is now waiting for a verbal command that matches a binding!
When it detects a binding, it will execute that bindings associated action **on the currently focused window, including the SoundSwitch itself.**

## Built With
* [nAudio](https://github.com/naudio/NAudio) - An open source .NET audio and MIDI library, containing dozens of useful audio related classes (for use when saving recorded sounds).
* [scape-xcorrsound](https://github.com/openpreserve/scape-xcorrsound) - Library that facilitates the generation of comparison values
between .wav files. We are using a modified version of this library to make it compatible with Windows.
