﻿using Newtonsoft.Json;

namespace CutieShop.Models.JSONEntities.Vision
{
    public static class Serialize
    {
        public static string ToJson(this VisionResult self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
