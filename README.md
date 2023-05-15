# Dungeon Crawl

## Story

[Roguelikes](https://en.wikipedia.org/wiki/Roguelike) are one of the oldest types of video games. The earliest ones were made in the 70s, and they were inspired a lot by tabletop RPGs. Roguelikes usually have the following features in common.

- They are tile-based.
- The game is divided into turns, that is, you take one action, then the other entities (monsters, allies, and so on, controlled by the CPU) take one.
- The task is usually to explore a labyrinth and retrieve some treasure from its bottom.
- They feature permadeath: if you die, it's game over, you need to start from the beginning again.
- They rely heavily on procedural generation: Levels, monster placement, items, and so on are randomized, so the game does not get boring.

Your task is to create a roguelike. You can deviate from the rules above, the important bit is that it should be fun.

## What are you going to learn?

- Get more practice in OOP.
- Understand layer separation.

## Tasks

1. Understand the existing code so you can make changes. Do this before planning anything else. It helps you understand what is going on.

   - A class diagram is created in a digialized format which contains the following.
     - enums, classes, interfaces with all fields, methods
     - connections between classes: inheritance, aggregation, composition
     - multiplicity of connections (1..1, 1..*, ..)

2. Create a game logic which restricts the movement of the player so they cannot run into walls and monsters.

    - The hero is not able to move into walls.
    - The hero is not able to move into monsters.

3. There are items lying around the dungeon. They are visible in the GUI.

    - There are at least two item types (for example, a key and a sword).
    - There can be one item in a map square.
    - A player can stand on the same square as an item.
    - The item must be displayed on screen (unless somebody stands on the same square).

4. Create a feature that allows the hero to pick up an item.

    - After the player steps on an item, it disappears from map.
    - After the player steps on an item, it is in the player's inventory.

5. Show picked up items in the inventory list.

    - There is an `Inventory` list on the screen.
    - After the hero picks up an item, it appears in the inventory.

6. Make the hero able to attack monsters by moving into them.

   - Attacking a monster removes 5 health points. If the health of a monster goes below 0, it dies and disappears.
   - If the hero attacks a monster and it does not die, it also attacks the hero at the same time (it only removes 2 health points).
   - Having a weapon increases attack strength.
   - Different monsters have different health and attack strengths.

7. Create three different monster types with different behaviors.

   - There are at least three different monster types with different behaviors.

8. Create maps that have more varied scenery.

   - At least three more tiles are used. These can be more monsters, items, or background. At least one of them must be not purely decorative, but have some effect on gameplay.

9. [OPTIONAL] Allow the player to set a name for the character. This name can also function as a cheat code.

   - There is a `Name` label and text field on the screen.
   - If the name given is one of the game developers' name, the player can walk through walls.

10. [OPTIONAL] Add the possibility to add more levels.

    - There are at least two levels.
    - There is a square type "stairs down". Entering this square moves the player to a different map.

11. [OPTIONAL] Create doors in the dungeon that are opened using keys.

    - There are two new square types, closed door and open door.
    - The hero cannot pass through a closed door unless there is a key in the inventory. After moving through, the closed door becomes an open door.

12. [OPTIONAL] Allow the user to save the current state of the game in a database.

    - The application uses a SQL database with at least one table.
    - When the user steps on the "save tile", the game saves the current state (current map, player position, and inventory content) in the database, overwriting the old game state (if there is one in the database).
    - When the user steps on the "load tile", the game loads the previously saved state (map, position, and inventory).

13. The customer looks for quality assurance and wants to see that your code is covered by unit tests. It is important to also cover negative scenarios, not only positive test cases.

    - Every unit test method is well-arranged and follows the `arrange-act-assert` structure.
    - Every test class has at least one negative test case (or more, if it is plausible).
    - Code coverage of self-created business logic classes is above 80%.

## General requirements

None

## Hints

- Start with the smaller tasks, and then move into the more difficult ones.
- Make sure you understand the whole starting code before making any changes.

## Background materials

- ❗ [Basics of OOP](https://journey.study/v2/learn/materials/pages/oop/basics-of-object-oriented-programming.md)
- ❗ [UML diagrams](https://journey.study/v2/learn/materials/pages/general/uml-unified-modeling-language.md)
- 📖 [UML cheat sheet](https://docs.google.com/file/d/1BOhDMCpSSWdn8cA2xQ4h8b3EYbI_ZWj5rb_LRJw583c/view)
- ❗ [How to design classes](https://journey.study/v2/learn/materials/pages/csharp/how-to-design-classes.md)
- 📖 [Architectural principles](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
- 📖 [Separation of Concerns](https://blog.ndepend.com/separation-of-concerns-explained/)
- 📖 [Get Started with SadConsole](https://sadconsole.com/v9/articles/tutorials/getting-started/part-1-drawing.html)
- 🍭 [SadConsole - Basic font information](https://sadconsole.com/v8/articles/basic-font-information.html)
