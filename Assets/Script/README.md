플레이 영상
https://www.youtube.com/watch?v=J6AP-euIyn4

에셋 폴더
https://github.com/jinborim/SECRETS-0F-THE-LAB

-----------------------------------------------------------------


퍼즐 및 기믹

퍼즐의 전체 로직과 개별 조각의 움직임을 관리

JigsawPuzzle.cs / PuzzlePiece.cs

퍼즐 완료 후 오브젝트를 치우거나 퍼즐 동작을 멈추는 보조 기능

PuzobjDelete.cs / PuzzleStop.cs

퍼즐의 성공/실패 여부를 판단하고 게임 흐름을 제어

PuzzleManager.cs

도끼를 사용해 특정 물건을 부수거나 상호작용하는 로직

AXE.cs

번호 키패드를 눌러 암호를 입력하는 기능을 담당

Keypad_touch.cs

인벤토리 및 아이템 시스템

인벤토리의 전체 틀과 아이템이 담기는 칸(슬롯), 드래그 앤 드롭 기능을 관리

Slot.cs / Inventory.cs

게임 내 모든 아이템의 데이터 베이스와 개별 아이템의 속성을 정의

ITEM_LIST.cs / Item.cs

필드에 있는 아이템을 클릭해서 인벤토리에 넣는 기능을 담당

ItemPickup.cs / Get_Item.cs

아이템끼리 합치거나(조합), 하나를 분해하는 로직의 기초

Combinationable.cs / decompositionable.cs

조합과 분해 기능이 잘 작동하는지 테스트하거나 실행하는 스크립트

ItemComb_Test.cs / ItemDecomp_Test.cs

인벤토리가 열려 있는지 확인하거나 아이템 버튼 클릭을 처리

Inventory_Checking.cs / Item_Btn.cs

아이템 조합/순서 로직

Combo_bath.cs

인벤토리 내에서 아이템을 드래그할 때 마우스 커서를 따라다니는 임시 슬롯 이미지를 제어

DragSlot.cs

아이템 세부 상호작용

아이템을 클릭했을 때 나오는 설명창의 기본 틀

Description_base.cs

설명창 안에 있는 조합, 분해, 나가기 버튼의 기능을 담당

CombBtn.cs / DecomBtn.cs / ExitBtn.cs

쪽지나 책처럼 읽을 수 있는 아이템의 텍스트를 보여주는 기능

Readable.cs / Read_Btn.cs

특정 상황에서 아이템을 강제로 추가하거나, 열쇠 아이템의 특수 로직

KEY.cs / Add_item.cs

화학 약품 혼합 등 특정 아이템 전용 기믹

Chemical.cs

알림 시스템

화면에 뜨는 알림창의 메인 로직

Alarm.cs / WOB_Alarm.cs

"예/아니오/확인" 등 플레이어의 선택 입력을 처리

Alarm_NoBtn.cs / Alarm_OkBtn.cs / Alarm_YesBtn.cs

효과 및 사운드

효과음 전체 관리와 오디오 클립 리스트를 관리

Effect_AudioClip_Manager.cs / EffectSound_Manager.cs

몬스터 전용 사운드(비명, 발소리 등)를 따로 관리하여 공포감을 조성

Monster_AudioClip_Manager.cs

화면이 어두워지거나 밝아지는(Fade In/Out) 연출을 담당

Faded.cs / DragSlot.cs

캐릭터 제어

플레이어의 실제 이동과 마우스 커서에 따른 시점 회전을 담당

MouseMove.cs / CharacterMovement.cs

게임 시작 시 플레이어의 위치나 초기 상태를 세팅

Set_Start.cs

상호작용 및 오브젝트 동작

서랍이나 캐비닛을 여닫는 동작

Drawer.cs / CabinetOpen.cs

특정 조건에서 벽이 부서지는 연출

BreakWall.cs

상자나 케이스를 옮기거나 여는 기능

CaseOpenclose.cs / CaseMove.cs

거울 반사 효과나 거울을 통한 힌트 노출

Mirror.cs

문의 개폐를 담당

Door3.cs / DoorOpen.cs

스위치를 켜거나 특정 장치를 가동하는 단순 트리거

on.cs

시스템 및 UI

대화창 시스템과 글자가 한 글자씩 써지는 타이핑 효과를 관리

DialogueSystem.cs / TypingManager.cs

대사 데이터를 보내거나 탈출 장면의 텍스트를 처리

TextSender.cs / EpText.cs

화면에 짧은 경고나 알림 문구를 뛰움

TextAlarm.cs

게임 흐름 및 연출

SceneController.cs / SceneController2.cs / GetOut.cs

탈출 성공/실패 시의 장면 환경 세팅

EPScene_Setting.cs

특정 위치에 가면 컷신(시네마틱)이 나오도록

CinematicTrigger.cs

오브젝트나 카메라가 항상 플레이어를 바라보게 고정

LookAtPlayer.cs

특정 상태나 씬을 변경하는 스크립트

Change.cs

기타 및 플랫폼

인게임 전반의 규칙을 담은 커스텀 스크립트

Script_igame.cs

물건을 집거나 특정 구역에 들어갔을 때 이벤트를 발생시키는 감지기

ObjectTrigger.cs / Puzzle_touch.cs

플레이어(또는 VR 컨트롤러)가 물건을 가리켰을 때 해당 물건을 강조하거나 인식하는 오브젝트 포인팅 및 하이라이트 기능을 담당

ObjectPoint.cs
