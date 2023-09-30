using CuotaPrestamos.Extensiones;
using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var context = new CustomAssemblyLoadContext();

context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(),
    "C:\\Users\\junio\\OneDrive\\Escritorio\\c# CURSO FULL\\CuotaPrestamos\\LibreriaPDF\\libwkhtmltox.dll"));


builder.Services.AddSingleton(typeof(IConverter),
    new SynchronizedConverter(new PdfTools()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DatosClientes}/{action=Crear}/{id?}");

app.Run();
