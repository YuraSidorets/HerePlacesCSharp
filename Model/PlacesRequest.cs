using System.Text;

namespace HerePlacesCSharp.Model
{
    public class PlacesRequest
    {
        internal string AppId { get; set; }

        internal string AppToken { get; set; }

        public string At { get; set; }

        public string Q { get; set; }

        public string In { get; set; }

        public string Route { get; set; }

        public string CompressedRoute { get; set; }

        public string DestinationPlaces { get; set; }

        public string ResultTypes { get; set; }

        public string Cs { get; set; }

        public string AddressFilter { get; set; }

        public string Recd { get; set; }

        public string Asr { get; set; }

        public string Size { get; set; }

        public string ShowRefs { get; set; }

        public string ShowContent { get; set; }

        public string Teasers { get; set; }

        public string ImageDimensions { get; set; }

        public string Urgency { get; set; }

        public string Tf { get; set; }

        public string Cat { get; set; }

        public string Drilldown { get; set; }

        public string Source { get; set; }

        public string PlaceId { get; set; }

        public string GetUriParameterString()
        {
            var uri = new StringBuilder();
            if (!string.IsNullOrEmpty(AppId))
            {
                uri.Append($"&app_id={AppId}");
            }

            if (!string.IsNullOrEmpty(AppId))
            {
                uri.Append($"&app_code={AppToken}");
            }

            if (!string.IsNullOrEmpty(At))
            {
                uri.Append($"&at={At}");
            }

            if (!string.IsNullOrEmpty(Q))
            {
                uri.Append($"&q={Q}");
            }

            if (!string.IsNullOrEmpty(In))
            {
                uri.Append($"&in={In}");
            }

            if (!string.IsNullOrEmpty(Route))
            {
                uri.Append($"&route={Route}");
            }

            if (!string.IsNullOrEmpty(CompressedRoute))
            {
                uri.Append($"&compressedRoute={CompressedRoute}");
            }

            if (!string.IsNullOrEmpty(DestinationPlaces))
            {
                uri.Append($"&destinationPlaces={DestinationPlaces}");
            }

            if (!string.IsNullOrEmpty(ResultTypes))
            {
                uri.Append($"&resultTypes={ResultTypes}");
            }

            if (!string.IsNullOrEmpty(Cs))
            {
                uri.Append($"&cs={Cs}");
            }

            if (!string.IsNullOrEmpty(AddressFilter))
            {
                uri.Append($"&addressFilter={AddressFilter}");
            }

            if (!string.IsNullOrEmpty(AddressFilter))
            {
                uri.Append($"&addressFilter={AddressFilter}");
            }

            if (!string.IsNullOrEmpty(Recd))
            {
                uri.Append($"&recd={Recd}");
            }

            if (!string.IsNullOrEmpty(Asr))
            {
                uri.Append($"&asr={Asr}");
            }

            if (!string.IsNullOrEmpty(Size))
            {
                uri.Append($"&size={Size}");
            }
       
            if (!string.IsNullOrEmpty(ShowRefs))
            {
                uri.Append($"&show_refs={ShowRefs}");
            }

            if (!string.IsNullOrEmpty(ShowContent))
            {
                uri.Append($"&show_content={ShowContent}");
            }

            if (!string.IsNullOrEmpty(Teasers))
            {
                uri.Append($"&teasers={Teasers}");
            }

            if (!string.IsNullOrEmpty(ImageDimensions))
            {
                uri.Append($"&image_dimensions={ImageDimensions}");
            }

            if (!string.IsNullOrEmpty(Urgency))
            {
                uri.Append($"&urgency={Urgency}");
            }

            if (!string.IsNullOrEmpty(Tf))
            {
                uri.Append($"&tf={Tf}");
            }

            if (!string.IsNullOrEmpty(Cat))
            {
                uri.Append($"&cat={Cat}");
            }
            
            if (!string.IsNullOrEmpty(Drilldown))
            {
                uri.Append($"&drilldown={Drilldown}");
            }

            if (!string.IsNullOrEmpty(Source))
            {
                uri.Append($"&source={Source}");
            }
            
            if (!string.IsNullOrEmpty(PlaceId))
            {
                uri.Append($"&id={PlaceId}");
            }

            // Remove first & symbol and replace with ?
            return $"?{uri.ToString().Remove(0,1)}";
        }
    }
}