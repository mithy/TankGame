﻿using Entitas;
using UnityEngine;
using System;

public sealed class AddViewSystem : ReactiveSystem<GameEntity> {

	private readonly Transform _viewContainer = new GameObject("Views").transform;
	private Contexts _contexts;

	public AddViewSystem(Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Asset);
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasAsset;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
		foreach (var entity in entities) {
			GameObject gameObject = GameObject.Instantiate(_contexts.game.globals.value.TankPrefab);

			if (gameObject != null) {
				gameObject.transform.parent = _viewContainer;
				entity.AddView(gameObject);
			}
		}
	}

}