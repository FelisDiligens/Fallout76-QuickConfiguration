using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public enum CameraPositionMode
    {
        Unarmed,
        Combat,
        MeleeCombat
    }

    partial class Form1
    {
        private CameraPositionMode camPosMode = CameraPositionMode.Unarmed;

        private float camOffsetMultiplier = 50;

        private float camOffsetToMetersRatio = 30; // I have no idea. We'll see.

        private void UpdateCameraPositionUI ()
        {
            this.trackBarCameraY.Enabled = camPosMode != CameraPositionMode.Unarmed;

            // ******************************************
            // ******** TODO: Update TrackBars! *********
            // ******************************************
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
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderPosX", value);
                    break;
                case CameraPositionMode.Combat:
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderCombatPosX", value);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatPosX", value);
                    break;
            }

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
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderCombatAddY", value);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatAddY", value);
                    break;
            }

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
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderPosZ", value);
                    break;
                case CameraPositionMode.Combat:
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderCombatPosZ", value);
                    break;
                case CameraPositionMode.MeleeCombat:
                    IniFiles.Instance.Set(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatPosZ", value);
                    break;
            }

            if (value < 0)
                Console.WriteLine($"Camera is offset downwards by {-value / camOffsetToMetersRatio} meters.");
            else if (value > 0)
                Console.WriteLine($"Camera is offset upwards by {value / camOffsetToMetersRatio} meters.");
            else
                Console.WriteLine($"Camera is vertically centered.");
        }

        private void buttonCameraPositionReset_Click(object sender, EventArgs e)
        {
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderPosX");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderPosZ");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderCombatPosX");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderCombatAddY");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderCombatPosZ");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatPosX");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatAddY");
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "fOverShoulderMeleeCombatPosZ");

            this.checkBoxbApplyCameraNodeAnimations.Checked = true;
            IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "bApplyCameraNodeAnimations");

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
    }
}
