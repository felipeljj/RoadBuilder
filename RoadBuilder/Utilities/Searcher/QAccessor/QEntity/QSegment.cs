﻿using RoadBuilder.Utilities.Searcher;

using Unity.Entities;
using Unity.Mathematics;

using UnityEngine;

namespace MoveIt.QAccessor
{
	internal partial struct QEntity
	{
		private readonly float3 Segment_Position => BezierPosition(Curve);

		private readonly float Segment_Angle
		{
			get
			{
				float3 mag = Curve.d - Curve.a;
				return math.atan2(mag.z, mag.x) * Mathf.Rad2Deg;
			}
		}

		private readonly quaternion Segment_Rotation => quaternion.EulerXYZ(0f, Angle, 0f);


		private bool Segment_SetUpdated()
		{
			TryAddUpdate(m_Entity);

			Game.Net.Edge edge = m_Lookup.gnEdge.GetRefRO(m_Entity).ValueRO;
			QEntity node = new(ref m_Lookup, edge.m_Start, Identity.Node);
			node.SetUpdated();
			node = new(ref m_Lookup, edge.m_End, Identity.Node);
			node.SetUpdated();

			if (TryGetComponent<Game.Net.Aggregated>(out var component))
			{
				Entity aggregate = component.m_Aggregate;
				TryAddUpdate(aggregate);
			}

			return true;
		}

	}
}
