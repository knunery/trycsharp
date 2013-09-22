using System.Collections.Generic;

namespace TryCSharp.Models
{
    public class Tutorial
    {
        public virtual ICollection<TutorialStep> Steps { get; set; }

        public static Tutorial TutorialData()
        {
            return new Tutorial()
                {
                    Steps = new List<TutorialStep>()
                    {
                       new TutorialStep() { Level = 1, Challenge = 1, Title = "Got 15 minutes? Take CSharp for a spin!", Instructions = 
@"
<p>CSharp is a powerful modern object oriented language.  It can be found powering slick websites via ASP .NET MVC, popular video games via Unity, and even IOS and Android apps via Xamarin.</p>
<p>Try out C# (pronounced ""see sharp"") in the prompt on the right.</p>
<ul>
   <li><code>help</code> → Start the 15 minute interactive tutorial. Trust me, it's very basic!</li>
   <li><code>clear</code> → Clear screen. Useful if your browser starts slowing down. Your command history will be remembered.</li>
   <li><code>next</code> → Allows you to skip to the next section of a lesson.</li>
   <li><code>back</code> → Allows you to skip to the previous section of a lesson.</li>
</ul>
"                        
                       },
                       new TutorialStep() {Level = 1, Challenge = 2,  Title = "Using the Prompt", Instructions = 
@"<p>The window to the right is a CSharp prompt!  Type a line of CSharp code, hit Enter watch it run!</p>

Type in <code>int k = 3 + 4;</code>" },
                       new TutorialStep() {Level = 1,  Challenge = 3, Title = "Say Your Name", Instructions = 
@"Sure, computers are handy and fast for math.
Let's move on. Want to see your name reversed?
Type your first name in quotes like this: <code>string name = ""Peter"";</code>" },
                       new TutorialStep() { Title = "", Instructions = "" }
                    },

                };
        }
    }
}