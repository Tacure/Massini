
namespace Massini.Core.Entities
{
    public delegate void ForEachTable<T1>(Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate void ForEachTable<T1, T2>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);
    public delegate void ForEachTable<T1, T2, T3>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2, Span<T3?> i_components3);
    public delegate void ForEachTable<T1, T2, T3, T4>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2, Span<T3?> i_components3, Span<T4?> i_components4);
    public delegate void ForEachTable<T1, T2, T3, T4, T5>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2, Span<T3?> i_components3, Span<T4?> i_components4, Span<T5?> i_components5);

    public delegate void ForEachTableWithParams<TParams, T1>(in TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate void ForEachTableWithParams<TParams, T1, T2>(in TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);
    public delegate void ForEachTableWithParams<TParams, T1, T2, T3>(in TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2, Span<T3?> i_components3);
    public delegate void ForEachTableWithParams<TParams, T1, T2, T3, T4>(in TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2, Span<T3?> i_components3, Span<T4?> i_components4);
    public delegate void ForEachTableWithParams<TParams, T1, T2, T3, T4, T5>(in TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2, Span<T3?> i_components3, Span<T4?> i_components4, Span<T5?> i_components5);

    public delegate TResult ForEachTableWithResult<T1, TResult>(Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate TResult ForEachTableWithResult<T1, T2, TResult>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);

    public delegate TResult ForEachTableWithResultAndParams<TParams, T1, TResult>(TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate TResult ForEachTableWithResultAndParams<TParams, T1, T2, TResult>(TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);


    public delegate void ForEachSpanAsync<T1>(Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate void ForEachSpanAsync<T1, T2>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);

    public delegate void ForEachSpanWithParamsAsync<TParams, T1>(TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate void ForEachSpanWithParamsAsync<TParams, T1, T2>(TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);

    public delegate TResult ForEachSpanWithResultAsync<T1, TResult>(Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate TResult ForEachSpanWithResultAsync<T1, T2, TResult>(Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);

    public delegate TResult ForEachSpanWithResultAndParamsAsync<TParams, T1, TResult>(TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1);
    public delegate TResult ForEachSpanWithResultAndParamsAsync<TParams, T1, T2, TResult>(TParams i_params, Span<Entity> i_entities, Span<T1?> i_components1, Span<T2?> i_components2);
}
