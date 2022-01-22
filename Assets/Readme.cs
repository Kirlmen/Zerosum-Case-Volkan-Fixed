/* Hey there! This is Zerosum's Case Project
 * 
 * It's about creating a stacking runner project using given assets.
 *
 * Main Target :
 * The character collects stacks and currencies and avoid obstacles while moving through the level towards finish line.
 *
 * Project using URP and game screen must be in portrait mode.
 * 
 * Basic needs for this project :
 * 
 * UI
 * -----
 *
 * There will be 3 screens :
 * - Tap To Play ++
 * - In Game ++
 * - Level End ++
 *
 *  Tap To Play :
 *      This screen will appear before starting a new level.
 * 
 *      It includes ;
 *      -Game Title (You can choose your own) ++
 *      -Tap To Play Button and Text ++
 *      -Current Level Number ++
 *      -Currency Amount ++
 *      -Start Stack Upgrade Button & Price ++
 *
 *      Start Stack Upgrade Button : ++
 *      This button will consume our currency and increase our starting stack.
 *
 *  In Game :
 *      This screen will appear while we are controlling the character.
 *
 *      It includes ;
 *      -Current Level Number ++
 *      -Currency Amount ++
 *      -Stack Amount ++
 *
 *      Stack Amount : ++
 *      This must be attached to and move with the character as smooth as possible.
 *
 *  Level End :
 *      This screen will appear after we reached our finish line.
 *
 *      It includes ;
 *      -Level Completed Text ++
 *      -Collected Currency Amount ++
 *      -Next Level Button ++
 *
 * !!UI elements must be responsive and works well with different resolutions.
 *      
 * GAMEPLAY
 * -----
 *
 *  Input :
 *      Character moves left and right with drag input. ++
 *      Movement needs to be simple and as smooth as possible.
 *
 *  Character :
 *      Character moves with the given animations. ++
 *      Character needs a maximum stack limit. ++
 *      Character animations need a transition between them.++
 *          If there is no stack "Run1", if stack is full "Run2" needs to be played.++
 *          States between also needs to affect the animation. ++
 *      Transitions needs to be as smooth as possible.
 *      On Level End, character must dance. ++
 *
 *  Collectables :
 *      There will be 2 types of collectables
 *      -Stack ++
 *      -Currency ++
 *
 *      Stack : Will increase out total stack amount. ++ 
 *      Currency : Will increase out total currency amount. ++
 *      
 *  Obstacles :
 *      Obstacles covers a part of the road. ++
 *      If character cannot avoid them, current stack amount will decrease. ++
 *
 *
 * GAME DATA
 * -----
 * 
 *  Levels :
 *      There must be minimum 2, maximum 5 different levels. ++
 *      Level number must increase if you reach finish. ++
 *      Level number must be remembered if game is closed and opened again. ++
 *      After your last unique level finished, you must repeat them. ++
 *
 *  Currency :
 *      Currency Amount must be remembered if game is closed and opened again. ++
 *      The amount will increase after collecting a currency collectable and, decreases after using upgrade button. ++
 *
 *  Start Stack Upgrade Button :
 *      Start stack represent the amount that our stack at start. ++
 *      Start stack start with 0 and increases by 1 with upgrade button on the tap to play screen.  ++
 *      Upgrade Button price increase exponentially on each purchase action. ++
 *      Start Stack amount must be remembered if game is closed and opened again. ++
 *      Upgrade Button price and level must be remembered if game is closed and opened again. ++
 *
 * !!You can define collectable values and upgrade prices by yourself. ++
 * !!There will be no fail condition. ++
 *
 *
 * !!IMPORTANT!!
 * * If you are new to this kind of projects, similar games are all over the market and successful examples can be reached easily.
 * * Yes, we want you to create a game but that's not it. Given instruction are just for basics of this project, so don't stop there.
 * * We want you to look from user's perspective and use your creative side. We are excited see your vision about the big picture.
 * * Use your imagination to create VFXs for actions in the game (including shaders).
 * * End product must be visually pleasing.
 * * Camera movements will be considered. 
 * * It's better to creating your own way but if you are comfortable with any third party tool or package,
 * you can use them in your game, of course with an explanation about the reason that you are using it.
 * * You can create your own levels but it's ok if you get templates from similar games.
 * * If you are feeling limited with animations, don't forget you have your character's model in t-pose.
 * * If you are feeling limited with models, don't hesitate about modifying them or you can always generate your own.
 * * If you are feeling limited with sprites, don't forget you can use sprite editor.
 * * If you are feeling limited with base texture colors, you can define your own colors.
 * * Feel free to make any kind of improvement.
 *
 * Project should be delivered in a week.
 *
 * Good luck and have a nice week!
 *
 *  * FAQ:
 * 
 * -What are we stacking?
 * We are collecting collectables and stacking its value.
 *
 * -How stacks will be shown?
 * It will be shown as a bar ui that bind to the character and follows it. Assets are given but you can create an use your own visuals.
 * Do not try to use them as upper or front stacks.
 *
 * -What happens when we collect or lost a stack collectable?
 *  If collected bar will be filled, if lost bar will be unfilled.
 * 
 */
