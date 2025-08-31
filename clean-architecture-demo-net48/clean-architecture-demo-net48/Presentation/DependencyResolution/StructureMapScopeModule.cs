using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.DependencyResolution {
    public class StructureMapScopeModule {
        private readonly RequestDelegate _next;

        #region Public Methods and Operators

        public void Dispose() {
        }

        public StructureMapScopeModule(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            // Here you would create your container scope
            try {
                await _next(context);
            }
            finally {
                // Here you would dispose your container scope
            }
        }
        #endregion
    }
}