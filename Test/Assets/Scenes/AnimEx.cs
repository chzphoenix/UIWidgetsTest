using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.cupertino;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace UIWidgetsSample
{
    public class AnimEx : UIWidgetsPanel
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
            TextAnim textAnim = new TextAnim();
            public override Widget build(BuildContext context)
            {
                return new Row(
                    children: new List<Widget> {
                        textAnim.build(context),
                        new CupertinoButton(onPressed: () => { textAnim.controller.forward(); },
                            child: new Text("Go"))
                    }
                   );
            }
        }

        private class TextAnim : SingleTickerProviderStateMixin<ExampleApp>
        {
            public AnimationController controller = null;
            public override Widget build(BuildContext context)
            {
                controller = new AnimationController(duration: new System.TimeSpan(0, 0, 2), vsync: this);
                controller.addStatusListener((status) => {
                    if(status == AnimationStatus.completed)
                    {
                        controller.reset();
                    }
                });
                Animation<Offset> offset = controller.drive(new OffsetTween(
                    begin: Offset.zero,
                    end: new Offset(0.0f, 2f)
                ));
                return new SlideTransition(
                            position: offset,
                            child: Unity.UIWidgets.widgets.Image.asset(
                                name: "test",
                                height: 100
                            )
                        );
            }
        }
    }

}