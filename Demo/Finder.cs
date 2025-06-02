using System.Linq;
using ObjectRepositories.Extensions;
using UnityEngine;

namespace ObjectRepositories
{
    public class Finder : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.V))
            {
                var units = this.FindObjectsOfTypeOnRepository<Unit>();
                foreach (var unit in units)
                {
                    Debug.Log(unit.name);
                }
            }
        }
    }
}