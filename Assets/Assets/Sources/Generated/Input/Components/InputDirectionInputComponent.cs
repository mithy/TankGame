//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity directionInputEntity { get { return GetGroup(InputMatcher.DirectionInput).GetSingleEntity(); } }
    public DirectionInputComponent directionInput { get { return directionInputEntity.directionInput; } }
    public bool hasDirectionInput { get { return directionInputEntity != null; } }

    public InputEntity SetDirectionInput(DirectionsEnum newValue) {
        if (hasDirectionInput) {
            throw new Entitas.EntitasException("Could not set DirectionInput!\n" + this + " already has an entity with DirectionInputComponent!",
                "You should check if the context already has a directionInputEntity before setting it or use context.ReplaceDirectionInput().");
        }
        var entity = CreateEntity();
        entity.AddDirectionInput(newValue);
        return entity;
    }

    public void ReplaceDirectionInput(DirectionsEnum newValue) {
        var entity = directionInputEntity;
        if (entity == null) {
            entity = SetDirectionInput(newValue);
        } else {
            entity.ReplaceDirectionInput(newValue);
        }
    }

    public void RemoveDirectionInput() {
        directionInputEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public DirectionInputComponent directionInput { get { return (DirectionInputComponent)GetComponent(InputComponentsLookup.DirectionInput); } }
    public bool hasDirectionInput { get { return HasComponent(InputComponentsLookup.DirectionInput); } }

    public void AddDirectionInput(DirectionsEnum newValue) {
        var index = InputComponentsLookup.DirectionInput;
        var component = CreateComponent<DirectionInputComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDirectionInput(DirectionsEnum newValue) {
        var index = InputComponentsLookup.DirectionInput;
        var component = CreateComponent<DirectionInputComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDirectionInput() {
        RemoveComponent(InputComponentsLookup.DirectionInput);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherDirectionInput;

    public static Entitas.IMatcher<InputEntity> DirectionInput {
        get {
            if (_matcherDirectionInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.DirectionInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherDirectionInput = matcher;
            }

            return _matcherDirectionInput;
        }
    }
}