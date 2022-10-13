using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Services;

namespace Yee.Section.Handlers
{
    public class ProtoHandler<T, V> : ComponentBase
        where T: IYeeProto<V>, new()
    {

        

        [Parameter]
        public EventCallback<T> OnInput { get; set; }

        [Parameter]
        public T? InputValue { get; set; }

        private V _model;
        protected V Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                Input();
            }
        }

        protected T Proto { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if(InputValue == null)
            {
                Proto = new();
                _model = NewModel;
                Proto.Value = Model;
            }
            else
            {
                Proto = InputValue;
                _model = Proto.Value;
            }
        }

        protected virtual V NewModel { get; }

        protected void Input()
        {
            Proto.Value = Model;
            OnInput.InvokeAsync(Proto);
        }

    }


}
