using System.Text;

namespace Hekki.Domain.Models
{
    public class Karts : List<int>
    {
        public Karts()
        {

        }

        public Karts(List<int> list)
        {
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item + ' ');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
