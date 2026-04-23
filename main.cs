using System;
using System.Collections.Generic;

public class Network
{
    private Dictionary<int, HashSet<int>> graph;
    private int size;

    public Network(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Numero invalido");

        size = n;
        graph = new Dictionary<int, HashSet<int>>();

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new HashSet<int>();
        }
    }

    public void Connect(int a, int b)
    {
        Validate(a, b);

        if (a == b) return;

        graph[a].Add(b);
        graph[b].Add(a);
    }

    public void Disconnect(int a, int b)
    {
        Validate(a, b);

        graph[a].Remove(b);
        graph[b].Remove(a);
    }

    public bool Query(int a, int b)
    {
        Validate(a, b);

        if (a == b) return true;

        var visited = new HashSet<int>();
        var queue = new Queue<int>();

        queue.Enqueue(a);
        visited.Add(a);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == b)
                return true;

            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    public int LevelConnection(int a, int b)
    {
        Validate(a, b);

        if (a == b) return 0;

        var visited = new HashSet<int>();
        var queue = new Queue<(int node, int level)>();

        queue.Enqueue((a, 0));
        visited.Add(a);

        while (queue.Count > 0)
        {
            var (current, level) = queue.Dequeue();

            if (current == b)
                return level;

            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue((neighbor, level + 1));
                }
            }
        }

        return 0;
    }

    private void Validate(int a, int b)
    {
        if (a < 1 || a > size || b < 1 || b > size)
            throw new ArgumentException("Elemento inválido");
    }
}