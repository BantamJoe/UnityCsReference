// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEngine;
using UnityEngineInternal;
using UnityEditor.SceneManagement;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

namespace UnityEditor
{
    // Various settings for the bake.
    [NativeHeader("Editor/Src/LightmapEditorSettings.h")]
    public static partial class LightmapEditorSettings
    {
        // Which baking backend is used.
        public enum Lightmapper
        {
            [Obsolete("Use Lightmapper.Enlighten instead. (UnityUpgradable) -> UnityEditor.LightmapEditorSettings/Lightmapper.Enlighten", true)]
            Radiosity = 0,

            // Lightmaps are baked by Enlighten
            Enlighten = 0,

            [Obsolete("Use Lightmapper.ProgressiveCPU instead. (UnityUpgradable) -> UnityEditor.LightmapEditorSettings/Lightmapper.ProgressiveCPU", true)]
            PathTracer = 1,

            // Lightmaps are baked by the Progressive lightmapper (Wintermute + OpenRL based).
            ProgressiveCPU = 1
        }

        // Which path tracer sampling scheme is used.
        public enum Sampling
        {
            // Convergence testing is automatic, stops when lightmap has converged.
            Auto = 0,

            // No convergence testing, always uses the given number of samples.
            Fixed = 1
        }

        // Set the path tracer filter mode.
        public enum FilterMode
        {
            // Do not filter.
            None = 0,

            // Select settings for filtering automatically
            Auto = 1,

            // Setup filtering manually
            Advanced = 2,
        }

        // Which path tracer filter is used.
        public enum FilterType
        {
            // A Gaussian filter is applied.
            Gaussian = 0,

            // An A-Trous filter is applied.
            ATrous = 1,

            // No filter
            None = 2
        }

        // Which baking backend is used.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("BakeBackend")]
        public extern static Lightmapper lightmapper { get; set; }

        // Which path tracer sampling scheme is used.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("PVRSampling")]
        public extern static Sampling sampling { get; set; }

        // Which path tracer filter is used for the direct light.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("PVRFilterTypeDirect")]
        public extern static FilterType filterTypeDirect { get; set; }

        // Which path tracer filter is used for the indirect light.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("PVRFilterTypeIndirect")]
        public extern static FilterType filterTypeIndirect { get; set; }

        // Which path tracer filter is used for AO.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("PVRFilterTypeAO")]
        public extern static FilterType filterTypeAO { get; set; }

        // Reset lightmapping settings
        [StaticAccessor("GetLightmapEditorSettings()")]
        extern internal static void Reset();

        [FreeFunction]
        extern static internal bool IsLightmappedOrDynamicLightmappedForRendering([NotNull] Renderer renderer);

        // Packing for realtime GI may fail of the mesh has zero UV or surface area. This is the outcome for the given renderer.
        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool HasZeroAreaMesh(Renderer renderer);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool HasUVOverlaps(Renderer renderer);

        // Packing for realtime GI may clamp the output resolution. This is the outcome for the given renderer.
        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool HasClampedResolution(Renderer renderer);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetSystemResolution(Renderer renderer, out int width, out int height);

        [FreeFunction("GetSystemResolution")]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetTerrainSystemResolution(Terrain terrain, out int width, out int height, out int numChunksInX, out int numChunksInY);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetInstanceResolution(Renderer renderer, out int width, out int height);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetInputSystemHash(Renderer renderer, out Hash128 inputSystemHash);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetInstanceHash(Renderer renderer, out Hash128 instanceHash);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetPVRInstanceHash(int instanceID, out Hash128 instanceHash);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetPVRAtlasHash(int instanceID, out Hash128 atlasHash);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetPVRAtlasInstanceOffset(int instanceID, out int atlasInstanceOffset);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal bool GetGeometryHash(Renderer renderer, out Hash128 geometryHash);

        [FreeFunction]
        [NativeHeader("Editor/Src/GI/EditorHelpers.h")]
        extern static internal void AnalyzeLighting(out LightingStats enabled, out LightingStats active, out LightingStats inactive);

        // The maximum size of an individual lightmap texture.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("AtlasSize")]
        public extern static int maxAtlasSize { get; set; }

        // Realtime lightmap resolution in texels per world unit. Also used for indirect resolution when using baked GI.
        [StaticAccessor("GetLightmapEditorSettings()")]
        public extern static float realtimeResolution { get; set; }

        // Static lightmap resolution in texels per world unit.
        [StaticAccessor("GetLightmapEditorSettings()")]
        public extern static float bakeResolution { get; set; }

        // Whether to use DXT1 compression on the generated lightmaps.
        [StaticAccessor("GetLightmapEditorSettings()")]
        public extern static bool textureCompression { get; set; }

        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("ReflectionCompression")]
        public extern static ReflectionCubemapCompression reflectionCubemapCompression { get; set; }

        // Wether to apply ambient occlusion to the lightmap.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("AO")]
        public extern static bool enableAmbientOcclusion { get; set; }

        // Beyond this distance a ray is considered to be unoccluded.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("AOMaxDistance")]
        public extern static float aoMaxDistance { get; set; }

        // Exponent for ambient occlusion on indirect lighting.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("CompAOExponent")]
        public extern static float aoExponentIndirect { get; set; }

        // Exponent for ambient occlusion on direct lighting.
        [StaticAccessor("GetLightmapEditorSettings()")]
        [NativeName("CompAOExponentDirect")]
        public extern static float aoExponentDirect { get; set; }

        // Texel separation between shapes.
        [StaticAccessor("GetLightmapEditorSettings()")]
        public extern static int padding { get; set; }

        [FreeFunction]
        [NativeHeader("Runtime/Graphics/LightmapSettings.h")]
        extern internal static UnityEngine.Object GetLightmapSettings();
    }
}
