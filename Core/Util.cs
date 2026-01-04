namespace EasyPackageAPI.Core;

internal static class Util
{
    /// <summary>
    /// add multiple new elements to an existing array
    /// </summary>
    /// <param name="originalArray"></param>
    /// <param name="newElements"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T[] AddElementsToArray<T>(T[] originalArray, T[] newElements)
    {
        // Create a new array with the combined size
        T[] newArray = new T[originalArray.Length + newElements.Length];

        // Copy the original array elements to the new array
        for (int i = 0; i < originalArray.Length; i++)
        {
            newArray[i] = originalArray[i];
        }

        // Copy the new elements to the end of the new array
        for (int i = 0; i < newElements.Length; i++)
        {
            newArray[originalArray.Length + i] = newElements[i];
        }
        
        return newArray;
    }
    
    /// <summary>
    /// add a new element to an existing array
    /// </summary>
    /// <param name="originalArray"></param>
    /// <param name="newElement"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T[] AddElementToArray<T>(T[] originalArray, T newElement)
    {
        // Create a new array with one more element
        T[] newArray = new T[originalArray.Length + 1];

        // Copy the original array elements to the new array
        for (int i = 0; i < originalArray.Length; i++)
        {
            newArray[i] = originalArray[i];
        }

        // Add the new element at the end
        newArray[newArray.Length - 1] = newElement;

        return newArray;
    }
}