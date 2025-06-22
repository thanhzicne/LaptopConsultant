document.addEventListener('DOMContentLoaded', function () {
    const needsChart = echarts.init(document.getElementById('needsChart'));
    const laptopsChart = echarts.init(document.getElementById('laptopsChart'));
    const brandsChart = echarts.init(document.getElementById('brandsChart'));

    // Dữ liệu từ ViewModel
    const topNeeds = @Html.Raw(JsonSerializer.Serialize(Model.TopNeeds));
    const topLaptops = @Html.Raw(JsonSerializer.Serialize(Model.TopLaptops));
    const topBrands = @Html.Raw(JsonSerializer.Serialize(Model.TopBrands));

    needsChart.setOption({
        title: { text: 'Top 5 Nhu cầu' },
        xAxis: { type: 'category', data: Object.keys(topNeeds) },
        yAxis: { type: 'value' },
        series: [{ type: 'bar', data: Object.values(topNeeds) }]
    });

    laptopsChart.setOption({
        title: { text: 'Top 5 Laptop' },
        xAxis: { type: 'category', data: Object.keys(topLaptops) },
        yAxis: { type: 'value' },
        series: [{ type: 'bar', data: Object.values(topLaptops) }]
    });

    brandsChart.setOption({
        title: { text: 'Top 5 Thương hiệu' },
        xAxis: { type: 'category', data: Object.keys(topBrands) },
        yAxis: { type: 'value' },
        series: [{ type: 'bar', data: Object.values(topBrands) }]
    });
});