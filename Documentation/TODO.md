# TODO

## IO

Should be based around the Unity InputSystem

- [ ] touchscreen/mouse interface
- [x] pc keys (way down the road also bind to console controls)
- [ ] Design interface
- [x] Redo the CardPositions clusterfuck.

## Game logic

- [x] Figure out what playing cards really are, implement deck and card classes.
- [x] Implement ShuffleDeck() and DrawCard() (and other methods)
- [x] Implement hit and stand mechanics
- [ ] Implement one-at-a-time mechanic for hit and stand: first hand3,2,1 then player to the left
- [ ] Automate the initial deal
- [ ] Implement play against cpu engine

## Documentation

- [x] Define and write down game mechanics
- [ ] Document the code structure and layout

## Assets

- [x] Make all assets modular
- [ ] Redo asset modularity using literally anything but AssetDatabase (Filesystem load?)
- [ ] Make a texture pack manager in settings
