using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using first_attempt.Services;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

namespace sec_attempt.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ApiService? _apiService = new ApiService();
    private readonly CouchDbService? _couchDbService = new CouchDbService();
    private readonly PostgresService? _postgresService = new PostgresService();

    public ISeries[] Series { get; set; } = [
        new ColumnSeries<int>(3, 4, 2),
        new ColumnSeries<int>(4, 2, 6),
        new ColumnSeries<double, DiamondGeometry>(4, 3, 4)
    ];

    private async Task CompareDBs()
    {
        await _apiService.DownloadAllToBothAsync(); // теперь загружает в обе БД
        await CompareDatabasesAsync();              // затем сразу сравнение
    }

    private async Task CompareDatabasesAsync()
    {
        /*var couchIds = await _couchDbService.GetAllActivityIdsAsync();
        var pgIds = await _postgresService.GetAllActivityIdsAsync();

        var onlyInCouch = couchIds.Except(pgIds).ToList();
        var onlyInPostgres = pgIds.Except(couchIds).ToList();
        var inBoth = couchIds.Intersect(pgIds).ToList();

        Console.WriteLine($"Всего в CouchDB: {couchIds.Count}");
        Console.WriteLine($"Всего в PostgreSQL: {pgIds.Count}");
        Console.WriteLine($"Общие записи: {inBoth.Count}");
        Console.WriteLine($"Только в CouchDB: {onlyInCouch.Count}");
        Console.WriteLine($"Только в PostgreSQL: {onlyInPostgres.Count}");

        UpdateComparisonResultListBox(couchIds, pgIds, onlyInCouch, onlyInPostgres, inBoth);*/
    }

    [RelayCommand]
    void Compare()
    {
        _ = CompareDBs();
    }
    [RelayCommand]
    void ShowStats()
    {
        
    }
}
