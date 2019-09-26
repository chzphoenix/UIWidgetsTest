using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.widgets;

namespace UIWidgetsSample
{
    public class ImageEx : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override Widget createWidget()
        {
            return new WidgetsApp(
                home: new ExampleApp(),
                pageRouteBuilder: (RouteSettings settings, WidgetBuilder builder) =>
                    new PageRouteBuilder(
                        settings: settings,
                        pageBuilder: (BuildContext context, Animation<float> animation,
                            Animation<float> secondaryAnimation) => builder(context)
                    )
            );
        }

        class ExampleApp : StatefulWidget
        {
            public ExampleApp(Key key = null) : base(key)
            {
            }

            public override State createState()
            {
                return new ExampleState();
            }
        }

        class ExampleState : State<ExampleApp>
        {

            public override Widget build(BuildContext context)
            {
                return new Column(
                    children: new List<Widget> {
                        //Unity.UIWidgets.widgets.Image.asset("test")
                        //Unity.UIWidgets.widgets.Image.network("https://www.baidu.com/img/dong_a16028f60eed614e4fa191786f32f417.gif")
                        Unity.UIWidgets.widgets.Image.asset(
                            name: "test",
                            height: 100,
                            width: 100,
                            fit: Unity.UIWidgets.painting.BoxFit.fill
                            )
                        }
                   );
            }
        }
    }
}