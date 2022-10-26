using Core.Domain;

namespace Portal.Models
{
    public static class ViewModelHelpers
    {
        public static List<Package> ToViewModel(this IEnumerable<Package> packages)
        {
            var result = new List<Package>();

            foreach (var package in packages)
            {
                result.Add(package);
            }

            return result;
        }
    }
}
