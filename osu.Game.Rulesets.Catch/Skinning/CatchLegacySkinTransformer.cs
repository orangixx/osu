// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Humanizer;
using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Textures;
using osu.Game.Audio;
using osu.Game.Skinning;
using osuTK;

namespace osu.Game.Rulesets.Catch.Skinning
{
    public class CatchLegacySkinTransformer : ISkin
    {
        private readonly ISkin source;

        public CatchLegacySkinTransformer(ISkinSource source)
        {
            this.source = source;
        }

        public Drawable GetDrawableComponent(ISkinComponent component)
        {
            if (!(component is CatchSkinComponent catchSkinComponent))
                return null;

            switch (catchSkinComponent.Component)
            {
                case CatchSkinComponents.FruitApple:
                case CatchSkinComponents.FruitBananas:
                case CatchSkinComponents.FruitOrange:
                case CatchSkinComponents.FruitGrapes:
                case CatchSkinComponents.FruitPear:
                    var lookupName = catchSkinComponent.Component.ToString().Kebaberize();
                    if (GetTexture(lookupName) != null)
                        return new LegacyFruitPiece(lookupName);

                    break;

                case CatchSkinComponents.Droplet:
                    if (GetTexture("fruit-drop") != null)
                        return new LegacyFruitPiece("fruit-drop") { Scale = new Vector2(0.8f) };

                    break;
            }

            return null;
        }

        public Texture GetTexture(string componentName) => source.GetTexture(componentName);

        public SampleChannel GetSample(ISampleInfo sample) => source.GetSample(sample);

        public IBindable<TValue> GetConfig<TLookup, TValue>(TLookup lookup) => source.GetConfig<TLookup, TValue>(lookup);
    }
}
