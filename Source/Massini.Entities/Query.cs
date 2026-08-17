
using Massini.Math;

namespace Massini.Entities
{
    public readonly partial struct Query
    {
        public Query WithNone<T>()
        {
            return new(m_storage, m_tables, m_exclude.Combine(m_storage.GetTypeMask(typeof(T))), m_includeSome);
        }

        public Query WithNone<T1, T2>()
        {
            Bitfield128 exclude = m_exclude;
            exclude = exclude.Combine(m_storage.GetTypeMask(typeof(T1)));
            exclude = exclude.Combine(m_storage.GetTypeMask(typeof(T2)));
            return new(m_storage, m_tables, exclude, m_includeSome);
        }

        public Query WhereHasSome<T>()
        {
            return new(m_storage, m_tables, m_exclude, m_includeSome.Combine(m_storage.GetTypeMask(typeof(T))));
        }

        public Query WhereHasSome<T1, T2>()
        {
            Bitfield128 includeSome = m_includeSome;
            includeSome = includeSome.Combine(m_storage.GetTypeMask(typeof(T1)));
            includeSome = includeSome.Combine(m_storage.GetTypeMask(typeof(T2)));
            return new(m_storage, m_tables, m_exclude, includeSome);
        }

        internal Query(Storage i_storage, IEnumerable<Table> i_tables, Bitfield128 i_exclude, Bitfield128 i_includeSome)
        {
            m_storage = i_storage;
            m_tables = i_tables;
            m_exclude = i_exclude;
            m_includeSome = i_includeSome;
        }

        private readonly Storage m_storage;
        private readonly IEnumerable<Table> m_tables;
        private readonly Bitfield128 m_exclude = Bitfield128.Zero;
        private readonly Bitfield128 m_includeSome = Bitfield128.Zero;

        private readonly bool CheckTableAgainstRules(Bitfield128 i_include, Table i_table)
        {
            return
                i_include.SubsetOf(i_table.TypesMask) &&
                !m_exclude.Overlap(i_table.TypesMask) &&
                (m_includeSome.Overlap(i_table.TypesMask) || m_includeSome.Equals(Bitfield128.Zero));
        }
    }

    public readonly partial struct Query
    {
        /* ////////////
        * WITHOUT DATA
        */////////////

        public readonly Query Do<T1>(ForEachTable<T1> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();

                i_action(entities, column1);
            }

            return this;
        }

        public readonly Query Do<T1, T2>(ForEachTable<T1, T2> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();
                Span<T2?> column2 = table.GetColumnAsSpan<T2>();

                i_action(entities, column1, column2);
            }

            return this;
        }

        /* ////////
        * WITH DATA
        *//////////

        public readonly Query Do<TParams, T1>(in TParams i_params, ForEachTableWithParams<TParams, T1> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();

                i_action(in i_params, entities, column1);
            }

            return this;
        }

        public readonly Query Do<TParams, T1, T2>(in TParams i_params, ForEachTableWithParams<TParams, T1, T2> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();
                Span<T2?> column2 = table.GetColumnAsSpan<T2>();

                i_action(in i_params, entities, column1, column2);
            }

            return this;
        }
    }

    public readonly partial struct Query
    {
        /*////////////
        * WITHOUT DATA
        */////////////

        public readonly IEnumerable<TResult> Compute<T1, TResult>(ForEachTableWithResult<T1, TResult> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();

                yield return i_action(entities, column1);
            }
        }

        public readonly IEnumerable<TResult> Compute<T1, T2, TResult>(ForEachTableWithResult<T1, T2, TResult> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();
                Span<T2?> column2 = table.GetColumnAsSpan<T2>();

                yield return i_action(entities, column1, column2);
            }
        }

        /*/////////
        * WITH DATA
        *//////////

        public readonly IEnumerable<TResult> Compute<TParams, T1, TResult>(TParams i_params, ForEachTableWithResultAndParams<TParams, T1, TResult> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();

                yield return i_action(i_params, entities, column1);
            }
        }

        public readonly IEnumerable<TResult> Compute<TParams, T1, T2, TResult>(TParams i_params, ForEachTableWithResultAndParams<TParams, T1, T2, TResult> i_action)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Span<Entity> entities = table.GetEntitiesAsSpan();
                Span<T1?> column1 = table.GetColumnAsSpan<T1>();
                Span<T2?> column2 = table.GetColumnAsSpan<T2>();

                yield return i_action(i_params, entities, column1, column2);
            }
        }
    }

    public readonly partial struct Query
    {
        /* ///////////
        * WITHOUT DATA
        */////////////

        public async Task DoAsync<T1>(ForEachSpanAsync<T1> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();

                await ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    i_action(entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count));
                });
            }
        }

        public async Task DoAsync<T1, T2>(ForEachSpanAsync<T1, T2> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();
                Memory<T2?> column2 = table.GetColumnAsMemory<T2>();

                await ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    i_action(entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count), column2.Span.Slice(i_start, i_count));
                });
            }
        }

        /*/////////
        * WITH DATA
        *//////////

        public async Task DoAsync<TParams, T1>(TParams i_params, ForEachSpanWithParamsAsync<TParams, T1> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();

                await ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    i_action(i_params, entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count));
                });
            }
        }

        private static async Task ForEachSpanAsyncHelper(int i_entitiesCount, int i_maxParallelism, Action<int, int> i_action)
        {
            if (i_entitiesCount == 0) return;

            i_maxParallelism = Math<int>.Max(i_maxParallelism, 1);
            i_maxParallelism = Math<int>.Min(i_entitiesCount, i_maxParallelism);

            // Divide the work into chunks and process them in parallel
            int chunkSize = i_entitiesCount / i_maxParallelism;
            int lastChunkSize = i_entitiesCount % i_maxParallelism;

            Task[] tasks = new Task[i_maxParallelism];

            for (int i = 0; i < i_maxParallelism; i++)
            {
                int start = i * chunkSize;
                int end = start + chunkSize;

                if (i == i_maxParallelism - 1)
                {
                    end += lastChunkSize;
                }

                tasks[i] = Task.Run(() => 
                {
                    i_action.Invoke(start, end - start);
                });
            }

            await Task.WhenAll(tasks);
        }
    }

    public readonly partial struct Query
    {
        /*////////////
        * WITHOUT DATA
        */////////////

        public readonly async IAsyncEnumerable<TResult> ComputeAsync<T1, TResult>(ForEachSpanWithResultAsync<T1, TResult> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();

                var result = ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    return i_action(entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count));
                });

                await foreach (TResult item in result)
                {
                    yield return item;
                }
            }
        }

        public readonly async IAsyncEnumerable<TResult> ComputeAsync<T1, T2, TResult>(ForEachSpanWithResultAsync<T1, T2, TResult> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();
                Memory<T2?> column2 = table.GetColumnAsMemory<T2>();

                var result = ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    return i_action(entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count), column2.Span.Slice(i_start, i_count));
                });

                await foreach (TResult item in result)
                {
                    yield return item;
                }
            }
        }

        /*/////////
        * WITH DATA
        *//////////

        public readonly async IAsyncEnumerable<TResult> ComputeAsync<TParams, T1, TResult>(TParams i_params, ForEachSpanWithResultAndParamsAsync<TParams, T1, TResult> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();

                var result = ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    return i_action(i_params, entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count));
                });

                await foreach (TResult item in result)
                {
                    yield return item;
                }
            }
        }

        public readonly async IAsyncEnumerable<TResult> ComputeAsync<TParams, T1, T2, TResult>(TParams i_params, ForEachSpanWithResultAndParamsAsync<TParams, T1, T2, TResult> i_action, int i_maxParallelism = 2)
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();
                Memory<T2?> column2 = table.GetColumnAsMemory<T2>();

                var result = ForEachSpanAsyncHelper(entities.Length, i_maxParallelism, (int i_start, int i_count) =>
                {
                    return i_action(i_params, entities.Span.Slice(i_start, i_count), column1.Span.Slice(i_start, i_count), column2.Span.Slice(i_start, i_count));
                });

                await foreach (TResult item in result)
                {
                    yield return item;
                }
            }
        }

        private static async IAsyncEnumerable<TResult> ForEachSpanAsyncHelper<TResult>(int i_entitiesCount, int i_maxParallelism, Func<int, int, TResult> i_action)
        {
            if (i_entitiesCount == 0) yield break;

            i_maxParallelism = Math<int>.Max(i_maxParallelism, 1);
            i_maxParallelism = Math<int>.Min(i_entitiesCount, i_maxParallelism);

            // Divide the work into chunks and process them in parallel
            int chunkSize = i_entitiesCount / i_maxParallelism;
            int lastChunkSize = i_entitiesCount % i_maxParallelism;

            for (int i = 0; i < i_maxParallelism; i++)
            {
                int start = i * chunkSize;
                int end = start + chunkSize;

                if (i == i_maxParallelism - 1)
                {
                    end += lastChunkSize;
                }

                yield return await Task.Run(() => 
                {
                    return i_action.Invoke(start, end - start);
                });
            }
        }
    }

    public readonly partial struct Query
    {
        public IEnumerable<(Entity Entity, T1? Component1)> Enum<T1>()
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();

                for (int i = 0; i < entities.Length; i++)
                {
                    yield return (entities.Span[i], column1.Span[i]);
                }
            }
        }

        public IEnumerable<(Entity Entity, T1? Component1, T2? Component2)> Enum<T1, T2>()
        {
            Bitfield128 include = Bitfield128.Zero;
            include = include.Combine(m_storage.GetTypeMask(typeof(T1)));
            include = include.Combine(m_storage.GetTypeMask(typeof(T2)));

            foreach (Table table in m_tables)
            {
                if (!CheckTableAgainstRules(include, table)) continue;

                Memory<Entity> entities = table.GetEntitiesAsMemory();
                Memory<T1?> column1 = table.GetColumnAsMemory<T1>();
                Memory<T2?> column2 = table.GetColumnAsMemory<T2>();

                for (int i = 0; i < entities.Length; i++)
                {
                    yield return (entities.Span[i], column1.Span[i], column2.Span[i]);
                }
            }
        }
    }
}