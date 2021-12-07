# PureSourceCode.com Extension for .NET5 
We have just released a lot of functions for [.NET5](https://www.puresourcecode.com/category/dotnet/) in a [NuGet package](https://www.nuget.org/packages/PSC.Extensions/) that you can download for free. We collected in this package functions for everyday work to help you with claim, strings, enums, date and time, expressions…

You can browse the full documentation [here](https://apps.puresourcecode.com/pscextensions). Please, give me your feedback in my [forum](https://www.puresourcecode.com/forum/) on [PureSourceCode.com](https://www.puresourcecode.com/).

## ClaimExtensions Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://user-images.githubusercontent.com/9497415/145021799-71853e5f-9f42-451c-81a6-a4bf0104386b.png) ![Static Method](https://user-images.githubusercontent.com/9497415/145021867-8353ffe5-4648-4f21-ad36-c345d277d10e.png)|GetClaim|Gets a claim from a list of claims|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|GetClaimValue|Gets the value of the requested claim if it exists|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|HasRole|Determines whether the specified role name has role.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|HasRoles|Determines whether the specified role name has roles.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|UpdateClaim|Updates a claim with a new value|

## Crypto
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|BytesToHex|Byteses to hexadecimal.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Decrypt|Decrypts the specified data.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Encrypt|Encrypts the specified data.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|HexToBytes|Hexadecimals to bytes.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|RandomString|Randoms the string (lowercase string)|

## DateExtensions Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|AscensionDay|Calculate Ascencion day|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|AshWednesday|Calculate Ash Wednesday|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ChristmasDay|Get the first day of christmas|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|DateDiff|Dates the difference.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|EasterSunday|Calculate Easter Sunday day|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|FirstSundayOfAdvent|Calculate the first Sunday of Advent|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|GetRandomDateTime|Generate random DateTime between range|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|GoodFriday|Calculate Good Friday|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|PalmSunday|Calculate Palm Sunday|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|WhitSunday|Calculate Whit Sunday|

## EnumerableExtensions Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|PickRandom<T>(IEnumerable<T>)|Return a random item for an IEnumerable T|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|PickRandom<T>(IEnumerable<T>, Int32)|Return a random item for an IEnumerable T|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Shuffle<T>)|Return source ordered by a new Guid|

## EnumExtension Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|GetLocalizedDescription|Gets localized description|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|GetDescription<T>|Gets the description.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ToEnum<T>(String)|Extension method to return an enum value of type T for the given string.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ToEnum<T>(Int32)|Extension method to return an enum value of type T for the given int.|

## ExpressionExtensions Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|And<T>|Combines the first predicate with the second using the logical "and".|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|BuildPredicate<T>|Builds the predicate.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Not<T>|Negates the predicate.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Or<T>|Combines the first predicate with the second using the logical "or".|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Replace|Replaces the specified search ex.|

## JsonSerializationExtension Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ReadFromJsonFile<T>|Reads an object instance from an Json file. Object type must have a parameterless constructor.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|WriteToJsonFile<T>|Writes the given object instance to a Json file. Object type must have a parameterless constructor.Only Public properties and variables will be written to the file. These can be any type though, even other classes.If there are public properties/variables that you do not want written to the file, decorate them with the `[JsonIgnore]` attribute.|

## ListExtensions Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|TrimSpace|Remove spece for each element of a list of string|

## StringExtensions Methods
||Name|Description|
|--- |--- |--- |
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|CheckIPValid|Checks the ip valid.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ExtractDomainNameFromURL|Extract a domain name from a full URL|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|GetLast|Gets the last.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|IPToNumber|Gets a number from a IPv4|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|IsDate|Determines whether the specified date is date.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|IsNumeric|Is the numeric.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|PadNumber|Pads the number.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|RandomString|Returns a random string with random alphanumeric characters|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|RemoveSpecialCharacter|Replace special character with another string|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ReplaceSpace|Replace spaces with another string|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|ReplaceSpecialCharacters|Replace non-ASCII characters with their ASCII value|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|Right|Return the last n characters from a string|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|StripHTML|Remove all HTML tags from a string|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|SubstringBetween|Takes a substring between two anchor strings (or the end of the string if that anchor is null)|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|TruncateString(String, Int32)|Truncate a string after maxLength characters.|
|![Public method](https://apps.puresourcecode.com/pscextensions/icons/pubmethod.gif "Public method") ![Static member](https://apps.puresourcecode.com/pscextensions/icons/static.gif "Static member")|TruncateString(String, Int32, Boolean)|Truncate a string after maxLength characters.|
