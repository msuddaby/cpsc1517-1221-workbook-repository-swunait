/*  Test Plan for Person
 *  
 *  Test Case                       Test Data                   Expected Result/Behaviour
 *  ---------                       ---------                   -------------------------
 *  Valid FullName                  FullName = Connor McDavid    FullName = Connor McDavid
 *  
 *  Null FullName                   FullName = null             ArgumentNullException with message
 *                                                              "FullName value is required"
 *  
 *  Empty FullName                  FullName = ""               ArgumentNullException
 *                                                              "FullName value is required"
 *  
 *  Whitespace FullName             FullName = "    "           ArgumentNullException
 *                                                              "FullName value is required"
 *  
 *  Full less than 3 characters     FullName = "AB"             ArgumentException
 * 
 * */

// Test Case 1: Valid FullName
using NhlSystem;

var validPerson = new Person("Connor McDavid");
Console.WriteLine(validPerson.FullName);    // The value should be Connor McDavid

// Test Case 2: Null FullName
try
{
    var nullPerson = new Person(null);
    Console.WriteLine("Null FullName Test Case failed.");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // The output should be "FullName value is required"
}

// Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine("Empty FullName Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // The output should be "FullName value is required"
}

// Test Case 4: Whitepsace FullName
try
{
    var whitespacePerson = new Person("      ");
    Console.WriteLine("Whitespace FullName Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // The output should be "FullName value is required"
}

// Test Case 5: Mininum Length FullName
try
{
    var invalidFullNameLengthPerson = new Person("AB");
    Console.WriteLine("FullName Length Test Case failed.");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // The output should be "FullName must contain 3 or more characters"
}