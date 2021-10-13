using BlazorComponentCommunicateUnilateralMediatR.Features.Styling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorComponentCommunicateUnilateralMediatR.Features.Styling
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
namespace BlazorComponentCommunicateUnilateralMediatR.Pages
{
    public partial class Counter : INotificationHandler<UpdateColorCommand>
    {
        public static event EventHandler<UpdateColorEventArgs> ColorChanged;
        public async Task Handle(UpdateColorCommand notification, CancellationToken cancellationToken)
        {
            ColorChanged?.in
        }
    }
}
