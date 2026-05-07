using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad
{
    public class SlidingDoor : MonoBehaviour
    {
        /**
         * 열고 닫히는 문의 상태 관리 및 열고 닫히는 애니메이션 제어를 담당
         * 네임스페이스를 통해 키패드 시스템과 그룹화
         */

        [SerializeField] private Animator anim; // 문 애니메이션을 제어할 컴포넌트
        
        // 문의 상태를 확인
        public bool IsOpoen => isOpen;
        private bool isOpen = false; // 현재 문이 닫힌 상태

        // 문의 상태를 반전 시키는 함수
        // 아이템과 상호작용 시 호출
        public void ToggleDoor()
        {
            // true -> false, false -> true 전환
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
        }

        // 문이 열린 상태
        public void OpenDoor()
        {
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
        }

        // 문이 닫힌 상태
        public void CloseDoor()
        {
            isOpen = false;
            anim.SetBool("isOpen", isOpen);
        }
    }
}