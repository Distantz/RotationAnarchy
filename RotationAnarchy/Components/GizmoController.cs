﻿namespace RotationAnarchy
{
    using RotationAnarchy.Internal;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class GizmoController : ModComponent
    {
        RotationAxisGizmo testGizmo;
        private int currentDebugMaterial;

        bool showDebugGizmo = true;

        public override void OnApplied()
        {
            testGizmo = new RotationAxisGizmo();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            testGizmo.SetActive(false);

            if (RA.Controller.Active)
            {
                if(RA.Controller.GameState == ParkitectState.Placement)
                {
                    var builder = RA.Controller.ActiveBuilder;
                    if(builder)
                    {
                        testGizmo.SetActive(true);
                        testGizmo.SnapToBuilder(builder);
                    }
                }
            }

            //if (Input.GetKeyDown(KeyCode.Keypad5))
            //    showDebugGizmo = !showDebugGizmo;
            //
            //if (showDebugGizmo && testGizmo != null && Camera.main != null)
            //{
            //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, float.MaxValue))
            //    {
            //        testGizmo.GameObject.transform.position = hit.point + new Vector3(0, 10, 0);
            //    }
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                var debug = GetComponent<RADebug>();
                testGizmo.material = debug.allMaterials[currentDebugMaterial++];
                if (currentDebugMaterial >= debug.allMaterials.Count)
                {
                    currentDebugMaterial = 0;
                }
            }
        }

        public override void OnReverted()
        {
            testGizmo.Destroy();
            testGizmo = null;
        }
    }


}