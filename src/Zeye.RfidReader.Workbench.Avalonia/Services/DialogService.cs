namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// 对话框服务。
/// </summary>
public sealed class DialogService : IDialogService
{
    /// <inheritdoc />
    public Task ShowMessageAsync(string title, string message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        return Task.CompletedTask;
    }
}
