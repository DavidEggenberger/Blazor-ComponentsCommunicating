using BlazorComponentsComunicateUnilateralYouTube.Features.Styling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorComponentsComunicateUnilateralYouTube.Features.Styling
{
    public class UpdateColorCommand : INotification
    {
        public string Color { get; set; }
    }
    public class UpdateColorEventArgs : EventArgs
    {
        public string Color { get; set; }
    }
}
namespace BlazorComponentsComunicateUnilateralYouTube.Pages
{
    public partial class Counter : INotificationHandler<UpdateColorCommand>
    {
        public static event EventHandler<UpdateColorEventArgs> ColorChanged;
        public async Task Handle(UpdateColorCommand notification, CancellationToken cancellationToken)
        {
            ColorChanged?.Invoke(this, new UpdateColorEventArgs { Color = notification.Color });
        }
    }
}
namespace BlazorComponentsComunicateUnilateralYouTube.Shared
{
    public partial class MainLayout : INotificationHandler<UpdateColorCommand>
    {
        public static event EventHandler<UpdateColorEventArgs> ColorChanged;
        public async Task Handle(UpdateColorCommand notification, CancellationToken cancellationToken)
        {
            ColorChanged?.Invoke(this, new UpdateColorEventArgs { Color = notification.Color });
        }
    }
}