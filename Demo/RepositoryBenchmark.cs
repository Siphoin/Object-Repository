using UnityEngine;
using System.Diagnostics;
using System.Linq;
using ObjectRepositories.Extensions;

namespace ObjectRepositories
{
    public class RepositoryBenchmark : MonoBehaviour
    {
        [SerializeField] private int _testObjectsCount = 1000;
        [SerializeField] private int _testIterations = 1000;

        [SerializeField] private Unit _unit;

        private void Start()
        {
            // Создаем тестовые объекты
            for (int i = 0; i < _testObjectsCount; i++)
            {
                var unit = Instantiate(_unit);
                unit.name = $"Unit{i}";
            }

            // Тестируем стандартный метод Unity
            var unityStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < _testIterations; i++)
            {
                var units = FindObjectsOfType<Unit>();
                var count = units.Length;
            }
            unityStopwatch.Stop();

            // Тестируем репозиторий
            var repoStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < _testIterations; i++)
            {
                var units = this.FindObjectsOfTypeOnRepository<Unit>();
                var count = units.Count();
            }
            repoStopwatch.Stop();

            // Выводим результаты
            UnityEngine.Debug.Log($"Benchmark results ({_testObjectsCount} objects, {_testIterations} iterations):");
            UnityEngine.Debug.Log($"Unity FindObjectsOfType: {unityStopwatch.ElapsedMilliseconds} ms");
            UnityEngine.Debug.Log($"Repository lookup: {repoStopwatch.ElapsedMilliseconds} ms");
            UnityEngine.Debug.Log($"Repository is {unityStopwatch.ElapsedMilliseconds / (float)repoStopwatch.ElapsedMilliseconds}x faster");
        }
    }
}