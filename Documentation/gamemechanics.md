# Crackjack — Technical Game Rules Specification

**Document Type:** Internal Game Design / Rules Specification  
**Audience:** Game Development Team  
**Status:** Stable ruleset (v1.0)

---

## 1. Game Summary

**Crackjack** is a multiplayer card game derived from blackjack mechanics, extended to simultaneous multi-hand play and combinatorial hand comparisons.

Each player manages **three independent blackjack hands** per round. After all hands are finalized, every hand is compared against every other player’s hands to generate points. The game emphasizes probabilistic optimization, risk distribution, and combinatorial scaling with player count.

---

## 2. Objective

The objective of the game is to be the **first player to reach a predefined target score**.

- The target score is configurable at game start.
- A player wins immediately upon reaching or exceeding the target score.

---

## 3. Players

- **Minimum players:** 2  
- **Maximum players:** Unbounded (practically limited by performance and deck size)

Game complexity and scoring scale exponentially with player count.

---

## 4. Components

- **Decks:**  
  - Any number of standard 52-card decks  
  - There is no upper limit; more decks are explicitly supported and encouraged

- **Scoring System:**  
  - Integer-based point tracking per player

---

## 5. Core Concepts

### 5.1 Hands

- Each player controls **exactly three hands** per round.
- Each hand is an independent blackjack hand.
- Hands are **face down** until all players have completed play.

### 5.2 Hand Values

Hand values follow standard blackjack rules:

| Card Type | Value |
|----------|-------|
| 2–10     | Face value |
| J, Q, K  | 10 |
| Ace      | 1 or 11 (whichever is optimal without busting) |

- A hand **busts** if its value exceeds 21.
- There is **no blackjack bonus** for a natural 21.
- Maximum hand size is implicitly limited by busting (no hard card cap).

---

## 6. Setup Phase

1. Shuffle all decks together into a single draw pile.
2. Deal **three sets of two cards** to each player.
3. Each set constitutes one hand.
4. All cards remain **face down**.

---

## 7. Play Phase (Hand Resolution)

Each player resolves their three hands independently.

For each hand, the player may repeatedly choose:

- **Hit:** Draw one card
- **Stand:** Stop drawing cards for that hand

Rules:

- Decisions for one hand do not affect the others.
- Players may choose different risk strategies per hand.
- Once a hand busts, it is immediately locked and cannot receive more cards.

The play phase ends only when **all players have stood or busted on all three hands**.

---

## 8. Comparison Phase

After all hands are finalized, the game enters the comparison phase.

### 8.1 Comparison Model

- Each player’s hands are compared against **every other player’s hands**.
- Comparisons are **pairwise and independent**.
- No dealer hand exists.

### 8.2 Comparison Rules

For any comparison between Hand A and Hand B:

- If one hand busts and the other does not → non-busted hand wins
- If both hands bust → tie
- If neither busts:
  - Higher value wins
  - Equal values result in a tie

---

## 9. Scoring

- **Win:** +1 point  
- **Loss:** 0 points  
- **Tie:** 0 points  

There are:

- No bonus points
- No penalties
- No carryover effects between hands

Points are awarded immediately after each comparison.

---

## 10. End of Round

1. All comparisons are resolved.
2. Points are tallied.
3. All cards are discarded.
4. Decks are reshuffled as needed.
5. A new round begins with fresh hands.

---

## 11. Victory Condition

- The game continues across multiple rounds.
- The first player to reach or exceed the configured target score **wins immediately**.
- If multiple players reach the target during the same round, the player with the highest total score wins.
  - Further tie-breaking rules may be implemented if required.

---

## 12. Design Notes (For Developers)

- The exponential comparison count (`3^n`) has significant performance implications for digital implementations.
- Parallelization of comparisons is strongly recommended.
- Hands should be treated as immutable after the play phase to simplify comparison logic.
- Face-down hands imply no shared state or information leakage during play.
- Increasing deck count reduces card depletion bias and improves statistical stability.

---

## 13. Explicit Non-Rules

The following mechanics are intentionally **not** part of Crackjack:

- No dealer
- No splitting
- No doubling down
- No insurance
- No blackjack bonus
- No card counting mitigation
- No hand interaction or merging

---

## 14. Versioning

- **v1.0** — Initial formalized ruleset

---
