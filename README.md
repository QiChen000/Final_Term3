# Nature in the City

Video: https://clipchamp.com/watch/lZ7clGs1FxT

Inspiration

When I was a child, many families in Beijing used to keep pigeons as a pastime. They often 
attached whistles to the pigeons, and when the pigeons flew in the sky, they created a 
beautiful sound as the wind passed through the whistle. It was like an aerial symphony. 
However, I rarely hear this sound now and I miss it. It's difficult for busy city dwellers to 
appreciate the beauty of nature.

In an episode of the Japanese TV drama "We Are Made of Miracles," the teacher led the 
students to the forest and used a tool to make bird calls, listening to the forest's response. It 
was truly wonderful. Inspired by this TV show and the principle of the pigeon whistle, I used 
ceramics to make two bird whistles that can control the flight of virtual forest birds with 
sound, allowing people in the city to experience the joy of nature.

Bird Whistle

I designed two bird whistles, one with the sound of an owl and the other with the sound of 
a sparrow. The audio for the owl whistle is relatively low, so the "belly" of the whistle is 
larger. I made many attempts and initially made the cover too thin, which prevented airflow 
from forming at the whistle mouth. I then tried widening the length of the whistle mouth, 
but after firing, the water content was lost and the mouth of the whistle became thinner, 
which I had not anticipated. However, there was sound produced this time, but it was not 
very loud. 

Designing the sparrow whistle was relatively smoother, and I also made two small holes at 
the belly and bottom of the whistle, like a flute, to produce changes in audio frequency.

Development Process

Controlling different birds with different instruments is a challenging task. I consulted with 
Rebecca, who advised me to use FFT to store audio data and analyze the audio range of 
different instruments for control. I also watched YouTube videos on how to use a 
microphone to capture instrument sounds. (Links provided: 
https://www.youtube.com/watch?v=GHc9RF258VA&t=11s for Microphone Input Visuals 
and https://www.youtube.com/watch?v=0KqwmcQqg0s&t=54s for Audio Visualization.) I 
imported the microphone audio into Audio Source, used FFT Get spectrum data to collect 
512 samples, allocated the samples to 8 channels, and visualized them as 8 audio bars. By 
testing the sounds of different instruments, I found the channel with the highest display, and 
thus the highest audio range. The channel with the highest display for low-frequency owl 
sounds was channel 2, while the channel with the highest display for high-frequency 
sparrow sounds was channel 3. Therefore, when I open a channel and recognize the highest 
channel, I can determine which bird is exhibiting behavior.

I determined bird behavior based on the length of the sound produced by playing the 
instrument. A longer sound indicates sustained flight, while a shorter sound indicates 
jumping.

However, when I tested it, I found that when I tested it for a while, the bird had delayed or 
even didn't move. Since the microphone receives in real-time, it is first stored in Audio source
and then analyzes the data. This process of data processing is more complicated before it 
gets stuck. So I set the microphone to record 30s and then reboot to continue recording.


