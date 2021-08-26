using System;
using System.Collections.Generic;
using System.Text;

namespace Constants.Settings
{
    public static class DatabaseSettings
    {
        public const string DATABASE_NAME = "Technical.db";
        public const string ERROR_BASE_MODEL_ONLY_ONE_KEY = "El objeto tiene mas de 1 llave primaria. Lo cual no permite la automatización de BaseModel en el Update";
        public const string ERROR_BASE_MODEL_PRIMARY_KEY = "El objeto no tiene llave primaria. Lo cual no permite la automatización de BaseModel en el Update";


    }
}
