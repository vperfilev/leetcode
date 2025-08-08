namespace ZyfraClub.Common;

public sealed class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public IEnumerable<int> Values
    {
        get
        {
            var head = this;
            var values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            return values;
        }
    }

    public static ListNode FromValues(int[] headValues)
    {
        var head = new ListNode(headValues[0]);
        var current = head;

        for (var i = 1; i < headValues.Length; i++)
        {
            current.next = new ListNode(headValues[i]);
            current = current.next;
        }

        return head;
    }
}