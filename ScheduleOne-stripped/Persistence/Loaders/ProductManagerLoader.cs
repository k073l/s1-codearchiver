using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class ProductManagerLoader : Loader
{
    public override void Load(string mainPath);
    private void SanitizeProductData(ProductData data);
    private void LoadProducts(ProductManagerData productData);
}