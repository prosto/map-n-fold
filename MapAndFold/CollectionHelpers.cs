namespace Alvys.MapAndFold
{
    public class CollectionHelpers
    {
        public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (f == null)
                throw new ArgumentNullException(nameof(f));

            var size = list.Count;

            var mappedList = new List<B>(size);
            foreach (A element in list)
            {
                mappedList.Add(f(element));
            }

            return mappedList;
        }

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (folder == null)
                throw new ArgumentNullException(nameof(folder));

            B result = initial;

            foreach (A element in list)
            {
                result = folder(result, element);
            }

            return result;
        }

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            return Fold(list, new List<B>(list.Count), (result, el) => { result.Add(f(el)); return result; });
        }
    }
}


