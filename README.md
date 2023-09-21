# THPRS
Authorizes with oauth 2.0 and has persistent refreshtoken use.
Uses a simple IRC interface for chat, later API's will be involved for more feedback.
Chat messages will be thrown onto a FiFo queue for process, order will be preserved.
The Keyword is changeable during listening without losing current entries.
The Keyword will be converted to upper case from both sides to compare in the background. Non-case sensitive.
Only checked names will be used in the raffle.
A modified version of Donald E. Knuth's subtractive random number generator is used(standard pseudo-random), more choices will be implemented in later versions.
Settings are available and persistent.
Ability to have multiple profiles is available thru saving and loading of files.

# Known Bugs
Missing limiter for sending messages, 12msg/min regular & 100msg/30s as mod