# Albumify 🎧

## Business Goals

| Stakeholder | Goal/Outcome | Context |
| --- | --- | --- |
| Me | Spend more time time listening to the music I like | I prefer listening to Albums. For the Albums I enjoy, there are hundreds, possibly thousands, of them spanning different genres, decades, and Artists. I often forget the Albums and Artists, so I end up listening to the same things repeatedly or wasting time trying to remember one.
| Me | Know when the Artists I like release a new Album/EP | I listen to too many Artists to keep in my mind. Currently, I find out about their new releases on accident |

## Architecturally Significant Requirements

### [Constraints](https://github.com/GoFightNguyen/design-it/blob/main/part-2-architecture-design-fundamentals/chapter-5-dig-for-architecturally-significant-requirements.md#limit-design-options-with-constraints)

| Constraint | Type | Context |
| --- | --- | --- |
| Client application must run on multiple operating systems including, but not limited to, Windows and iOS | Technical | I listen to music across multiple devices and scenarios |
| Must utilize managed, free cloud offerings | Business, Technical | Reduces my spend to as close to $0 as possible, while allowing me to focus on value-add |
| Use dotnet | Technical | Reduce the breadth of learning required by me. Although there are many worthwhile tech stacks to consider, my main focus is value-add rather than learning |

## Risks

| Condition | Consequence | Mitigation Approach |
| --- | --- | --- |
| My dev time to this project is limited | project is left in a hard-to-maintain state | reduce probability using lean |
| My dev time to this project is limited | project is filled with unreliable features | reduce probability using lean |
| My current streaming service is Spotify | change to something cheaper/better | accept and do nothing by dealing with the risk if it actually occurs |

[Risks and how to reduce or remove them](https://github.com/GoFightNguyen/design-it/blob/main/part-2-architecture-design-fundamentals/chapter-3-devise-a-design-strategy.md#let-risk-be-your-guide)