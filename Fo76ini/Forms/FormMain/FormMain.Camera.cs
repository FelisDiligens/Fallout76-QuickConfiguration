using System;

namespace Fo76ini
{
    public enum CameraPositionMode
    {
        Unarmed,
        Combat,
        MeleeCombat
    }

    partial class FormMain
    {
#if false
        private CameraPositionMode camPosMode = CameraPositionMode.Unarmed;

        private float camOffsetMultiplier = 50;

        private float camOffsetToMetersRatio = 30; // I have no idea. We'll see.

        private void UpdateCameraPositionUI()
        {
            this.trackBarCameraY.Enabled = camPosMode != CameraPositionMode.Unarmed;

            int rangeX = Math.Abs(trackBarCameraX.Maximum) + Math.Abs(trackBarCameraX.Minimum);
            int rangeY = Math.Abs(trackBarCameraY.Maximum) + Math.Abs(trackBarCameraY.Minimum);
            int rangeZ = Math.Abs(trackBarCameraZ.Maximum) + Math.Abs(trackBarCameraZ.Minimum);

            float x, y, z;

            switch (camPosMode)
            {
                case CameraPositionMode.Unarmed:
                    x = IniFiles.GetFloat("Camera", "fOverShoulderPosX", 0);
                    z = IniFiles.GetFloat("Camera", "fOverShoulderPosZ", 0);
                    this.trackBarCameraX.Value = (int)(x / camOffsetMultiplier * rangeX / 2);
                    this.trackBarCameraY.Value = 0;
                    this.trackBarCameraZ.Value = (int)(z / camOffsetMultiplier * rangeZ / 2);
                    break;
                case CameraPositionMode.Combat:
                    x = IniFiles.GetFloat("Camera", "fOverShoulderCombatPosX", 0);
                    y = IniFiles.GetFloat("Camera", "fOverShoulderCombatAddY", 0);
                    z = IniFiles.GetFloat("Camera", "fOverShoulderCombatPosZ", 0);
                    this.trackBarCameraX.Value = (int)(x / camOffsetMultiplier * rangeX / 2);
                    this.trackBarCameraY.Value = (int)(y / camOffsetMultiplier * rangeY / 2);
                    this.trackBarCameraZ.Value = (int)(z / camOffsetMultiplier * rangeZ / 2);
                    break;
                case CameraPositionMode.MeleeCombat:
                    x = IniFiles.GetFloat("Camera", "fOverShoulderMeleeCombatPosX", 0);
                    y = IniFiles.GetFloat("Camera", "fOverShoulderMeleeCombatAddY", 0);
                    z = IniFiles.GetFloat("Camera", "fOverShoulderMeleeCombatPosZ", 0);
                    this.trackBarCameraX.Value = (int)(x / camOffsetMultiplier * rangeX / 2);
                    this.trackBarCameraY.Value = (int)(y / camOffsetMultiplier * rangeY / 2);
                    this.trackBarCameraZ.Value = (int)(z / camOffsetMultiplier * rangeZ / 2);
                    break;
            }
        }

        // Not correct: ~X: - Right, + Left~
        // Correct: X: - Left, + Right
        private void trackBarCameraX_Scroll(object sender, EventArgs e)
        {
            int range = Math.Abs(trackBarCameraX.Maximum) + Math.Abs(trackBarCameraX.Minimum);
            //int inverse = trackBarCameraX.Value * -1;
            float normalized = (float)trackBarCameraX.Value / (float)range * 2f;

            float value = normalized * camOffsetMultiplier;

            switch (camPosMode)
            {
                case CameraPositionMode.Unarmed:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderPosX", value);
                    break;
                case CameraPositionMode.Combat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderCombatPosX", value);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderMeleeCombatPosX", value);
                    break;
            }

            this.checkBoxbApplyCameraNodeAnimations.Checked = false;
            IniFiles.F76Custom.Set("Camera", "bApplyCameraNodeAnimations", false);

            if (value < 0)
                Console.WriteLine($"Camera is offset to the left by {-value / camOffsetToMetersRatio} meters.");
            else if (value > 0)
                Console.WriteLine($"Camera is offset to the right by {value / camOffsetToMetersRatio} meters.");
            else
                Console.WriteLine($"Camera is horizontally centered.");
        }

        // Y: - Zoom Out, + Zoom In.
        private void trackBarCameraY_Scroll(object sender, EventArgs e)
        {
            int range = Math.Abs(trackBarCameraY.Maximum) + Math.Abs(trackBarCameraY.Minimum);
            float normalized = (float)trackBarCameraY.Value / (float)range * 2f;

            float value = normalized * camOffsetMultiplier;

            switch (camPosMode)
            {
                case CameraPositionMode.Combat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderCombatAddY", value);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderMeleeCombatAddY", value);
                    break;
            }

            this.checkBoxbApplyCameraNodeAnimations.Checked = false;
            IniFiles.F76Custom.Set("Camera", "bApplyCameraNodeAnimations", false);

            if (value < 0)
                Console.WriteLine($"Camera is zoomed out by {-value / camOffsetToMetersRatio} meters.");
            else if (value > 0)
                Console.WriteLine($"Camera is zoomed in by {value / camOffsetToMetersRatio} meters.");
            else
                Console.WriteLine($"Camera isn't zoomed.");
        }

        // Z: - Down, + Up.
        private void trackBarCameraZ_Scroll(object sender, EventArgs e)
        {
            int range = Math.Abs(trackBarCameraZ.Maximum) + Math.Abs(trackBarCameraZ.Minimum);
            float normalized = (float)trackBarCameraZ.Value / (float)range * 2f;

            float value = normalized * camOffsetMultiplier;

            switch (camPosMode)
            {
                case CameraPositionMode.Unarmed:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderPosZ", value);
                    break;
                case CameraPositionMode.Combat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderCombatPosZ", value);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderMeleeCombatPosZ", value);
                    break;
            }

            this.checkBoxbApplyCameraNodeAnimations.Checked = false;
            IniFiles.F76Custom.Set("Camera", "bApplyCameraNodeAnimations", false);

            if (value < 0)
                Console.WriteLine($"Camera is offset downwards by {-value / camOffsetToMetersRatio} meters.");
            else if (value > 0)
                Console.WriteLine($"Camera is offset upwards by {value / camOffsetToMetersRatio} meters.");
            else
                Console.WriteLine($"Camera is vertically centered.");
        }

        private void buttonCameraPositionReset_Click(object sender, EventArgs e)
        {
            this.checkBoxbApplyCameraNodeAnimations.Checked = true;

            IniFiles.F76Custom.Remove("Camera", "fOverShoulderPosX");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderPosZ");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderCombatPosX");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderCombatAddY");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderCombatPosZ");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderMeleeCombatPosX");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderMeleeCombatAddY");
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderMeleeCombatPosZ");
            IniFiles.F76Custom.Remove("Camera", "bApplyCameraNodeAnimations");

            UpdateCameraPositionUI();
        }

        private void buttonCameraPositionCenter_Click(object sender, EventArgs e)
        {
            switch (camPosMode)
            {
                case CameraPositionMode.Unarmed:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderPosX", 0);
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderPosZ", 0);
                    break;
                case CameraPositionMode.Combat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderCombatPosX", 0);
                    //IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderCombatAddY", value);
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderCombatPosZ", 0);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderMeleeCombatPosX", 0);
                    //IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatAddY", value);
                    IniFiles.F76Custom.Set("Camera", "fOverShoulderMeleeCombatPosZ", 0);
                    break;
            }

            this.checkBoxbApplyCameraNodeAnimations.Checked = false;
            IniFiles.F76Custom.Set("Camera", "bApplyCameraNodeAnimations", false);

            UpdateCameraPositionUI();
        }

        private void radioButtonCameraPositionUnarmed_CheckedChanged(object sender, EventArgs e)
        {
            camPosMode = CameraPositionMode.Unarmed;
            UpdateCameraPositionUI();
        }

        private void radioButtonCameraPositionCombat_CheckedChanged(object sender, EventArgs e)
        {
            camPosMode = CameraPositionMode.Combat;
            UpdateCameraPositionUI();
        }

        private void radioButtonCameraPositionMeleeCombat_CheckedChanged(object sender, EventArgs e)
        {
            camPosMode = CameraPositionMode.MeleeCombat;
            UpdateCameraPositionUI();
        }
#endif
    }
}
