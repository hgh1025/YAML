using System;
using System.Collections.Generic;
using System.Dynamic;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

public class ExpandoObjectTypeConverter : IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(ExpandoObject);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        var obj = new ExpandoObject() as IDictionary<string, object>;

        while (parser.Current is not MappingEnd)
        {
            parser.MoveNext();
            var key = parser.Current as Scalar;
            parser.MoveNext();
            var value = parser.Current as Scalar;

            obj.Add(key.Value, value.Value);
        }

        parser.MoveNext(); // Consume MappingEnd

        return obj;
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        var obj = value as IDictionary<string, object>;
        emitter.Emit(new MappingStart());

        foreach (var pair in obj)
        {
            emitter.Emit(new Scalar(pair.Key));
            emitter.Emit(new Scalar(pair.Value.ToString()));
        }

        emitter.Emit(new MappingEnd());
    }
}
