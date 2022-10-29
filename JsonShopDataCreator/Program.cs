using JsonShopDataCreator;

var source = "D:\\output-onlinetsvtools.json";
var dest = "D:\\sklep.json";
var parser = new FileParser(source);
var products = parser.GetProducts();
var writer = new FileWriter(dest, products);
writer.SaveFile();
