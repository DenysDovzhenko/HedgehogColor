# HedgehogColor
*OOP solution for cute hedgehogs! They are really moving!*
Imagine that you have a meadow where hedgehogs are playing. They are colored in three different colors - red, green, and blue (RGB).

One day, two hedgehogs of different colors meet by chance, and then they both change their color to the opposite, third color. This ability fascinated the hedgehogs, and they agreed to plan their meetings so that they could all become the same color.

The task of the program, or rather objects of the `Playground` class, is to determine the most effective meeting plan for hedgehogs.

To start using this program you can simply create `Playground` instance and launch `PlanMeetings()` public method.
**Example**:
```
Playground happyHedgehogs = new Playground(0, [8, 1, 9]);
Console.WriteLine(happyHedgehogs.PlanMeetings());
```

Having trouble reading code quickly? Check out the tips below.

## Testing
For testing, I use methods that have already been written, you can use them for your own tests, or you can simply check the operation of the `Playground` class object yourself. 

The defined single-case testing methods return a `Playground` object, which allows you to continue experimenting with it.

`TestPlayground(int[], int)` method

This is a single case method that outputs to the console only the number of hedgehog encounters based on the input data.

**Params**:

`hedgehogsNum` - `Int32[]` array, where each value is the number of hedgehogs of a certain color, according to the index.

`color` - `Int32`, index of the desired color.

**Return**:

`Playground` - object that was tested.
\n

`TestPlaygroundHedgehogs(int[], int)` method

This is a single case method that outputs to the console the number of hedgehog encounters and checks whether the `Playground` object has right number of hedgehogs each color.

**Params**:

`hedgehogsNum` - `Int32` array, where each value is the number of hedgehogs of a certain color, according to the index.

`color` - `Int32`, index of the desired color.

**Return**:

`Playground` - object that was tested.


`TestPlaygrounds(int[], int, testMethod)` method

This is a method that iterates over all variants of each color from 1 to the color value of the array and prints tests result to the console.

For me, it was convenient to use this method, but it's true that it's not perfect and will definitely not be convenient for many (`hedgehogsCount`).

**Params**:

`hedgehogsCount` - `Int32` array, where each value is the number of iterations for each hedgehog color.

`color` - `Int32`, index of the desired color.

`test` - `testMethod` method, how to test playground definition. Defined single case methods are acceptable.


`testMethod(int[], int)` delegate


## Classes description
### Playground class
Abstraction of the lawn, the environment in which the hedgehogs live.


`MeetNumber` - public `Int32` property *+getter +private setter*, hedgehog meetings number.

`HedgehogColors` - public `Int32[]` array property *+getter -setter*, a container for storing data on the number of hedgehogs of each color.

`DesiredColor` - public `Colors` property *+getter -setter*, the color that all hedgehogs want.

`Hedgehogs` - public `List<Hedgehog>` property *+getter -setter*, list for storing hedgehog objects on the `Playground`.

`Playground(int[], int)` - constructor. Initializes the object and verify input data.


`PlanMeetings()` public method

Start planning hedgehog meetings. If it is too easy or impossible, the planning ends here and the hedgehogs get a conclusion about the number of minimum meetings.

**Return**:

`int` - -1 if it is impossible to completely change the color of the hedgehogs; otherwise, minimal meetings number


`CheckHedgehogsColor(Colors)` public method

Checks whether the specified number of hedgehogs of a certain color matches the actual number.

**Params**:

`checkColor` - `Colors` enum object, which color to check.

**Return**:

`bool` - true if the specified number of hedgehogs is equal to the actual number, otherwise false.


`ValidateInputs(int[], int)` private method

Abstraction of valid argument checks when creating a Playground object.

**Params**:

`hedgehogsNumbers` - `Int32[]` array, where each value is the number of hedgehogs of a certain color, according to the index.

`desiredColor` - `Int32`, index of the desired color.

**Exceptions**:

`ArgumentOutOfRangeException` - invalid color index.

`ArgumentNullException` - color number array cannot be null.

`ArgumentException` - invalid number of hedgehog colors provided or sum of hedgehog numbers should be between 1 and int.MaxValue.


`InitializeHedgehogs()` private method

Abstraction over initializing a list of hedgehogs (`List<Hedgehogs> Hedgehogs`).


`StartMeetings(OtherColors)` private method

Fulfillment of a complex meeting plan. Performed when hedgehogs can become the same color, but there is no easy way.

**Params**:

`color` - `OtherColors` struct, set of two colors that are not desired.

**Return**:

`int` - minimal meetings number.


`HedgehogsMeeting(List<Hedgehog>, OtherColors, int)` private method

Fast implementation for ONE hedgehogs meeting.

**Params**:

`fullGrroup` - `List<Hedgehog>` list object, container for hedgehogs.

`hedgehogColors` - `OtherColors` struct, set of two colors for hedgehogs to meet.

`mainColor` - `Int32`, color index of the increased hedgehogs population.


`HedgehogsMeetings(List<Hedgehog>, OtherColors, int, int)` private method

Implementation for MANY hedgehogs meetings.

**Params**:

`fullGroup` - `List<Hedgehog>` list object, container for hedgehogs.

`hedgehogColors` - `OtherColors` struct, set of two colors for hedgehogs to meet.

`meetingsNum` - `Int32`, how many times hedgehogs have to meet.

`mainColor` - `Int32`, color index of the increased hedgehogs population.


`GetHedgehog(List<Hedgehog>, Colors)` private method

Get the first hedgehog of a certain color from the list.

**Params**:

`fullGroup` - `List<Hedgehog>` list object, container for hedgehogs.

`wantedColor` - `Colors` enum object, color of the desired hedgehog.

**Return**:

`Hedgehog` - found hedgehog.


`GetHedgehogGroup(List<Hedgehog>, Colors, int)` private method

Get the first given number of hedgehogs of a certain color from the list.

**Params**:

`fullGroup` - `List<Hedgehog>` list object, container for hedgehogs.

`wantedColor` - `Colors` enum object, color of the desired hedgehogs.

`takeNum` - `Int32`, how many hedgehogs to return.

**Return**:

`IEnumerable<Hedgehog>` - collection of found hedgehogs.


`ChangeHedgehogsNumber(OtherColors, int, int)` private method

Method for changing the record of the number of hedgehogs in the `HedgehogColors` array.

**Params**:

`otherColors` - `OtherColors` struct, set of two colors for hedgehogs to meet.

`meetingsNum` - `Int32`, how many times hedgehogs have to meet.

`mainColor` - `Int32`, color index of the increased hedgehogs population.


`HedgehogOutsidersColor(Colors)` private method

Method for determining colors other than the specified ones.

**Params**:

`mainColor` - `Colors` enum object, specified color.

**Return**:

`OtherColors` - set of two not specified colors.

**Exceptions**:

`ArgumentException` - `mainColor` is invalid color.


`ThereAreOneColorHedgehogs()` private method

Checks if all hedgehogs on the playground are the same color.

**Return**:

`bool` - true, if there are all hedgehogs the same, otherwise false.


`OtherHedgehogsHavePairs(int, int)` private method

An abstraction of checking the equality of two numbers, when hedgehogs can already reach the goal by following a simple plan to meet the corresponding hedgehogs of the opposite color.

**Params**:

`groupNumber1` - `Int32`, number of hedgehogs in first group.

`groupNumber2` - `Int32`, number of hedgehogs in second group.

**Return**:

`bool` - true if `groupNumber1` equal `groupNumber2`, otherwise false.


`CanMergeIntoOneColor(int, int)` private method

Checks whether there are ways to solve the problem.

**Params**:

`groupNumber1` - `Int32`, number of hedgehogs in first group.

`groupNumber2` - `Int32`, number of hedgehogs in second group.

**Return**:

`bool` - true if hedgehogs can merge into one color, otherwise false.


### Hedgehog class
Class represents a hedgehog with a particular color, and it contains methods to interact with other hedgehogs.

`color` - public `Colors` property *+getter +setter*, hedgehog color.

`Hedgehog(Colors)` - constructor. Initializes the object.


`MeetHedgehog(Hedgehog)` public method

The method performs a meeting of *this* hedgehog with *another* hedgehog.

**Params**:

`otherHedgehog` - `Hedgehog` object, encountered hedgehog.

**Exceptions**:

`HedgehogException` - represents an exception thrown when hedgehogs of the same color meet.


`PickColor(Colors, Colors)` private method

The method is designed to get the third color of the hedgehog color to change to.

**Params**:

`color1` - `Colors` enum object, first color.

`color2` - `Colors` enum object, second color.

**Return**:

`Colors` - third color to change.

**Exceptions**:

`InvalidOperationException` - invalid colors combination.


### OtherColors struct
*readonly*

The 'OtherColors' structure stores data about a pair of color indices that define the types of hedgehogs to meet.

`First` - public `Int32` property *+getter -setter*, first index of the color.

`Second` - public `Int32` property *+getter -setter*, second index of the color.

`OtherColors(int, int)` - constructor. Initializes the object.


### Colors enum
An additional level of abstraction for easy use of colors and improved code readability. `Colors` values corresponding to possible hedgehog colors indexes.
```
Red == 0
Green == 1
Blue == 2
```


### HedgehogException exception
It is custom exception derived from `System.Exception` with default implementation. Represents an exception thrown when hedgehogs of the same color meet.


# NOTES
* The main feature of this solution is accessibility to code improvements.
* My next idea for improving the code is to define the action of the hedgehogs at the moment they meet using the delegate. The method definition for this delegate could be when creating the hedgehog object.
* It is possible to increase code security by adding more exceptions.
* This may affect the readability of the code, but it is possible to replace the immediate `HedgehogMeeting()` with storing the number of changes that will simply execute `HedgehogsMeeting()`, which will be faster than calling `HedgehogMeeting()` multiple times.
