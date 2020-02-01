

live_loop :base_chords do
  with_fx :reverb do
    random_arpeggio chord(:C3, :major)
    random_arpeggio chord_invert(chord(:A2, :minor), 1)
    random_arpeggio chord_invert(chord(:F2, :major), 2)
    random_arpeggio chord_invert(chord(:G2, :major), 2)
  end
end

define :random_arpeggio do |ring|
  play ring, release: 4.5
  play :C2, release: 1, amp: 0.75
  play choose(ring), release: 0.5
  sleep 1
  play choose(ring), release: 0.5
  sleep 1
  play choose(ring), release: 0.5
  sleep 1
  play choose(ring), release: 0.5
  sleep 1
end