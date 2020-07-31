using System;

namespace BeginerLearnProjrct {
    class Sort<T> where T : IComparable<T> {
        private static void Swap(ref T a, ref T b) {
            T c = a;
            a = b;
            b = c;
        }
        public static void BubbleSort(T[] arr) {
            for(int i = 0; i < arr.Length; i++) {
                for(int j = 0; j < arr.Length - 1; j++) {
                    if(arr[j].CompareTo(arr[j + 1]) > 0) {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        public static void InsertSort(T[] arr) {
            T min;
            int ind_min;
            for(int i = 0; i < arr.Length; i++) {
                min = arr[i];
                ind_min = i;
                for(int j = i + 1; j < arr.Length; j++) {
                    if(min.CompareTo(arr[j]) > 0) {
                        min = arr[j];
                        ind_min = j;
                    }
                }
                Swap(ref arr[i], ref arr[ind_min]);
            }
        }
        public static void GnomeSort(T[] arr) {
            int i = 0;
            while(i < arr.Length - 1) {
                if(arr[i].CompareTo(arr[i + 1]) > 0) {
                    Swap(ref arr[i], ref arr[i + 1]);
                    if(i != 0) {
                        i--;
                    }
                }
                else {
                    i++;
                }
            }
        }
        public static void QuickSort(T[] arr, int left, int right) {
            T pivot = arr[left];
            bool l = false;
            bool r = false;
            int p_right = right;
            int p_left = left + 1;
            while(p_left <= p_right) {
                if(l == false) {
                    if(pivot.CompareTo(arr[p_left]) > 0) {
                        p_left++;
                    }
                    else {
                        l = true;
                    }
                }
                if(r == false) {
                    if(pivot.CompareTo(arr[p_right]) <= 0) {
                        p_right--;
                    }
                    else {
                        r = true;
                    }
                }
                if(l == true && r == true) {
                    Swap(ref arr[p_left], ref arr[p_right]);
                    l = false;
                    r = false;
                }
            }
            Swap(ref arr[left], ref arr[p_right]);
            if(p_right - left > 1) {
                QuickSort(arr, left, p_right - 1);
            }
            if(right - p_right > 1) {
                QuickSort(arr, p_right + 1, right);
            }
        }
    }
}
