using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

app.MapGet("/", async () =>
{
    return Results.Text("Hello world");
});

app.Run();

public class Record
{
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public string ?Ticket { get; set; }
    public string ?Customer { get; set; }
    public string ?Technician { get; set; }
    public string ?State { get; set; }
    public string ?Notes { get; set; }
}

public static class RecordDB
{
    private static readonly string path = "../records.json";
    private static List<Record> records = new List<Record>();

    public static List<Record> GetRecords()
    {
        return records;
    }

    public static void Load()
    {
        try
        {
            using (StreamReader SR = new StreamReader(path))
            {
                string json = SR.ReadToEnd();

                records = JsonConvert.DeserializeObject<List<Record>>(json);
                Save();
            }
            Console.WriteLine($"Loaded DB - Record count {records.Count}");
        }
    }

    public static void Save()
    {

    }
}