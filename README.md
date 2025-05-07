# Jars.AI Assessment

Hey folks! Alexander Winn here, with my code assessment. Here's a brief rundown of what I've got, and I'd be happy to walk through it with you if you'd like.

- All Baseline Requirements are complete.
- All Core Technical Evaluation Points are complete.
- Polish items completed: 
    - Added subtle "hover" and "tapped" color shifts on all buttons
    - Added drag-to-rotate functionality for character
    - Added Control Panel with play, pause, and restart buttons
    - Added "No _____ animations available" label for empty categories
    - Added "unselect" functionality for Category tabs (click again to unselect)
- Code implementation highlights:
    - Categories and Animations are implemented as ScriptableObjects, for easy editing in the Inspector
    - Animation duration is procedurally detected and set, for one less thing to forget about
    - "TabCell" and "AnimationCell" are subclasses of "Cell" for shared functionality (mostly the "selected" state color change)
    - Variable and method names are non-abbreviated and easily understood, and class fields are grouped under explanatory Headers
    - Explanatory comments (e.g. in ViewController.RefreshAnimationsList)
    - Singleton pattern for ViewController class 
	

A few ideas for further polish, and why I didn't implement them now:
- "Bouncy" buttons scaling down during tap (the current color scheme is dark enough that the scaling isn't noticeable).
- EventManager class for futher code decoupling (for a codebase this small it seemed like over-optimization).
- Loading indicator (not necessary for meshes and animations this light).
- Improved character positioning relative to UI, for varying screen sizes/shapes (see Other Notes below).

Other notes:
- As I mentioned in my call with Chris, character animations are a weak spot for me due to my experience being mainly in strategy and menu-based games, so there may be optimizations and opportunities there which I missed.
- The Figma included seven categories, but the Assets folder only included six animations. I sorted them into categories myself, but that still left some empty categories. The ScriptableObject implementation will allow for rapid updating and expanding of the animation library, though.

Please let me know if you have any questions, and I look forward to hearing from you!

-Alexander Winn
