using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(menuName = "Custom/Stack")]
public class PostProcessingStack : ScriptableObject//, IEnumerable<PostProcessingEffect>
{
    [SerializeField] private List<PostProcessingEffect> effects;
    public int Size { get {
            if (effects == null) return -1;
            return effects.Count;
        }
    }

    public PostProcessingEffect GetIndex(int index) {
        return effects[index];
    }

    /*
    public IEnumerator<PostProcessingEffect> GetEnumerator() {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return new Enumerator(this);
    }

    public class Enumerator : IEnumerator<PostProcessingEffect> {
        private PostProcessingStack stack;
        private int index;
        
        internal Enumerator(PostProcessingStack _stack) {
            stack = _stack;
            index = 0;
        }

        public PostProcessingEffect Current { get {
                if (index < 0) throw new UnityException("InvalidOperationException");
                return stack.GetIndex(index);
            }
        }

        object IEnumerator.Current { get {
                if (index < 0) throw new UnityException("InvalidOperationException");
                return stack.GetIndex(index);
            }
        }

        public void Dispose() {
            index = -1;
        }

        public bool MoveNext() {
            if (index < 0) throw new UnityException("Cant MoveNext on Disposed stack");

            index++;
            if (index >= stack.Size) return false;
            else return true;
        }

        public void Reset() {
            index = 0;
        }
    }
    */
}
